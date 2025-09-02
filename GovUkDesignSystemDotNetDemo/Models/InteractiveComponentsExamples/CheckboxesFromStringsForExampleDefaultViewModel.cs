using GovUkDesignSystemDotNet;

namespace GovUkDesignSystemDotNetDemo.Models.InteractiveComponentsExamples;

public class CheckboxesFromStringsForExampleDefaultViewModel
{
    [GovUkValidateCheckboxNumberOfResponsesRange(
        ErrorMessageIfNothingSelected = "Select at least two years",
        MinimumSelected = 2
        )]
    public List<string> Years { get; set; } = [];
}
