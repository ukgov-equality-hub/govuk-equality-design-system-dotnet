using System.ComponentModel.DataAnnotations;

namespace GovUkDesignSystemDotNetDemo.Models.InteractiveComponentsExamples;

public class CheckboxItemForExampleDefaultViewModel
{
    [AllowedValues(true, ErrorMessage = "Confirm you agree to the declaration")]
    public bool ConfirmDeclaration { get; set; }
}
