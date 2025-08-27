using System.ComponentModel.DataAnnotations;

namespace GovUkDesignSystemDotNet;

[AttributeUsage(AttributeTargets.Property)]
public class GovUkValidateRequiredIfAttribute: GovUkValidateRequiredAttribute
{
    public string IsRequiredPropertyName;

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var isRequiredPropertyInfo = validationContext.ObjectInstance.GetType().GetProperty(IsRequiredPropertyName);
            
        if (isRequiredPropertyInfo == null)
        {
            throw new ArgumentException(
                $"'{IsRequiredPropertyName}' must be a boolean property in the model the attribute is included in");
        }
        
        var isRequired = (bool)isRequiredPropertyInfo.GetValue(validationContext.ObjectInstance, null)!;
            
        if (isRequired && value is null)
        {
            return new ValidationResult(ErrorMessageIfMissing);
        }
        return ValidationResult.Success;
    }
}
