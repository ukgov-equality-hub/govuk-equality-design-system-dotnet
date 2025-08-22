using GovUkDesignSystemDotNet;

namespace GovUkDesignSystemDotNetDemo.Models.InteractiveComponentsExamples;

public class TextareaForExampleDefaultViewModel
{
    [GovUkValidateRequired(ErrorMessageIfMissing = "Enter more detail")]
    public string MoreDetail { get; set; }
}
