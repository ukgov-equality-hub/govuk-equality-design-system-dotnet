
locals {
  main_app_elastic_beanstalk_solution_stack_name = "64bit Amazon Linux 2023 v3.2.2 running .NET 8"
  main_app_elastic_beanstalk_ec2_instance_type = "t4g.nano"
  main_app_elastic_beanstalk_root_volume_size = 8  // Disk space (in GB) to give each EC2 instance

  main_app_elastic_beanstalk_health_check_path = "/health-check"  // It would be nice if this was a dedicated "/health-check" endpoint that's unauthenticated
  main_app_elastic_beanstalk_health_check_matcher_http_code = 200
}


// An S3 bucket to store the code that is deployed by Elastic Beanstalk
resource "aws_s3_bucket" "main_app_elastic_beanstalk_code_s3_bucket" {
  bucket_prefix = lower("${var.service_name_hyphens}--${var.environment_hyphens}--S3-Beanstalk-")
}

resource "aws_s3_bucket_public_access_block" "main_app_elastic_beanstalk_code_s3_bucket_public_access_block" {
  bucket = aws_s3_bucket.main_app_elastic_beanstalk_code_s3_bucket.id

  block_public_acls       = true
  block_public_policy     = true
  ignore_public_acls      = true
  restrict_public_buckets = true
}


resource "aws_elastic_beanstalk_application" "main_app_elastic_beanstalk_application" {
  name        = "${var.service_name}__${var.environment}__Elastic_Beanstalk_Application"
}


resource "aws_elastic_beanstalk_environment" "main_app_elastic_beanstalk_environment" {
  name                = "${var.service_name_hyphens}--${var.environment_hyphens}--EB-Env"
  application         = aws_elastic_beanstalk_application.main_app_elastic_beanstalk_application.name

  tier                = "WebServer"
  solution_stack_name = local.main_app_elastic_beanstalk_solution_stack_name
  cname_prefix        = "${var.service_name_hyphens}--${var.environment_hyphens}"


  // See this documentation for all the available settings
  // https://docs.aws.amazon.com/elasticbeanstalk/latest/dg/command-options-general.html

  ///////////////
  // VPC
  setting {
    namespace = "aws:ec2:vpc"
    name      = "VPCId"
    value     = aws_vpc.vpc_main.id
  }
  setting {
    namespace = "aws:ec2:vpc"
    name      = "Subnets"
    value     = join(",", [aws_subnet.vpc_main__public_subnet_az1.id])
  }
  setting {
    namespace = "aws:ec2:vpc"
    name      = "AssociatePublicIpAddress"
    value     = true
  }


  /////////////////////
  // Instances
  setting {
    namespace = "aws:ec2:instances"
    name      = "InstanceTypes"
    value     = local.main_app_elastic_beanstalk_ec2_instance_type
  }

  setting {
    namespace = "aws:autoscaling:launchconfiguration"
    name      = "IamInstanceProfile"
    value     = aws_iam_instance_profile.iam_instance_profile__instances.name
  }
  setting {
    namespace = "aws:autoscaling:launchconfiguration"
    name      = "SecurityGroups"
    value     = aws_security_group.security_group_main_app_instances.id
  }
  setting {
    namespace = "aws:autoscaling:launchconfiguration"
    name      = "MonitoringInterval"
    value     = "1 minute"
  }

  setting {
    namespace = "aws:autoscaling:launchconfiguration"
    name      = "RootVolumeType"
    value     = "gp3"
  }
  setting {
    namespace = "aws:autoscaling:launchconfiguration"
    name      = "RootVolumeSize"
    value     = local.main_app_elastic_beanstalk_root_volume_size
  }


  /////////////////////////
  // Load Balancer
  setting {
    namespace = "aws:elasticbeanstalk:environment"
    name      = "EnvironmentType"
    value     = "SingleInstance"
  }
  

  ///////////////////////
  // Deployments
  setting {
    namespace = "aws:elasticbeanstalk:command"
    name      = "DeploymentPolicy"
    value     = "AllAtOnce"
  }
  setting {
    namespace = "aws:elasticbeanstalk:command"
    name      = "BatchSizeType"
    value     = "Fixed"
  }
  setting {
    namespace = "aws:elasticbeanstalk:command"
    name      = "BatchSize"
    value     = 1
  }


  ///////////////////////////
  // Sticky Sessions
  setting {
    namespace = "aws:elasticbeanstalk:environment:process:default"
    name      = "StickinessEnabled"
    value     = false
  }


  /////////////////////////
  // Health Checks
  setting {
    namespace = "aws:elasticbeanstalk:environment:process:default"
    name      = "HealthCheckPath"
    value     = local.main_app_elastic_beanstalk_health_check_path
  }
  setting {
    namespace = "aws:elasticbeanstalk:environment:process:default"
    name      = "HealthCheckInterval"
    value     = 15
  }
  setting {
    namespace = "aws:elasticbeanstalk:environment:process:default"
    name      = "HealthCheckTimeout"
    value     = 5
  }
  setting {
    namespace = "aws:elasticbeanstalk:environment:process:default"
    name      = "MatcherHTTPCode"
    value     = local.main_app_elastic_beanstalk_health_check_matcher_http_code
  }
  setting {
    namespace = "aws:elasticbeanstalk:environment:process:default"
    name      = "DeregistrationDelay"
    value     = 20
  }
  setting {
    namespace = "aws:elasticbeanstalk:environment:process:default"
    name      = "HealthyThresholdCount"
    value     = 3
  }
  setting {
    namespace = "aws:elasticbeanstalk:environment:process:default"
    name      = "UnhealthyThresholdCount"
    value     = 5
  }


  //////////////////////
  // CloudWatch
  setting {
    namespace = "aws:elasticbeanstalk:cloudwatch:logs"
    name      = "RetentionInDays"
    value     = 30
  }
  setting {
    namespace = "aws:elasticbeanstalk:cloudwatch:logs"
    name      = "StreamLogs"
    value     = true
  }
  setting {
    namespace = "aws:elasticbeanstalk:cloudwatch:logs"
    name      = "DeleteOnTerminate"
    value     = false
  }

  setting {
    namespace = "aws:elasticbeanstalk:cloudwatch:logs:health"
    name      = "RetentionInDays"
    value     = 30
  }
  setting {
    namespace = "aws:elasticbeanstalk:cloudwatch:logs:health"
    name      = "HealthStreamingEnabled"
    value     = true
  }
  setting {
    namespace = "aws:elasticbeanstalk:cloudwatch:logs:health"
    name      = "DeleteOnTerminate"
    value     = false
  }
}
