
variable "service_name" {
  type = string
  description = "The short name of the service."
  default = "designsys_dotnet"
}
variable "service_name_hyphens" {
  type = string
  description = "The short name of the service (using hyphen-style)."
  default = "designsys-dotnet"
}

variable "environment" {
  type = string
  description = "The environment name."
}
variable "environment_hyphens" {
  type = string
  description = "The environment name (using hyphen-style)."
}

variable "github_url" {
  type = string
  description = "The URL to the GitHub repo (we add this as a Tag to all resources)"
}

variable "create_dns_record" {
  type = bool
  description = "Should terraform create a Route53 alias record for the (sub)domain"
}
variable "dns_record_subdomain_including_dot" {
  type = string
  description = "The subdomain (including dot - e.g. 'dev.' or just '' for production) for the Route53 alias record"
}
