using GovUkDesignSystemDotNet;

namespace GovUkDesignSystemDotNetDemo.Models.InteractiveComponentsExamples;

public class CharacterCountForExampleDefaultViewModel
{
    [GovUkValidateRequired(ErrorMessageIfMissing = "Enter more detail")]
    [GovUkValidateCharacterCount(Limit = 200, Units = CharacterCountMaxLengthUnit.Words, NameAtStartOfSentence = "Details", NameWithinSentence = "more details")]
    public string MoreDetail { get; set; }
}
