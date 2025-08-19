using GovUkDesignSystemDotNet;

namespace GovUkDesignSystemDotNetDemo.Models.InteractiveComponentsExamples;

public class TextInputForExampleDefaultViewModel
{
    [GovUkValidateRequired(ErrorMessageIfMissing = "Please enter your first name")]
    public string FirstName { get; set; }
    
    [GovUkValidateRequired(ErrorMessageIfMissing = "Please enter your last name")]
    public string LastName { get; set; }
}
