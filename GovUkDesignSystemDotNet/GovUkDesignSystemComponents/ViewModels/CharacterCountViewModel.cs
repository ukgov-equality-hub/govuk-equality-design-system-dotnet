namespace GovUkDesignSystemDotNet;

public class CharacterCountViewModel : IHasErrorMessage
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int? Rows { get; set; }
    public string Value { get; set; }
    public CharacterCountLimitViewModel Limit { get; set; }
    public double? Threshold { get; set; }
    public LabelViewModel Label { get; set; }
    public HintViewModel Hint { get; set; }
    public ErrorMessageViewModel ErrorMessage { get; set; }
    public FormGroupViewModel FormGroup { get; set; }
    public List<string> Classes { get; set; } = [];
    public Dictionary<string, string> Attributes { get; set; }
    public bool Spellcheck { get; set; }
    public string Autocomplete { get; set; }
    public bool Disabled { get; set; }
    public List<string> CountMessageClasses { get; set; } = [];
    public string TextareaDescriptionText { get; set; }
    public PluralisationOptions UnderLimitText { get; set; }
    public string AtLimitText { get; set; }
    public PluralisationOptions OverLimitText { get; set; }
}

public class CharacterCountLimitViewModel
{
    public int Limit { get; }
    public CharacterCountMaxLengthUnit Units { get; }

    public bool IsCharacters => Units == CharacterCountMaxLengthUnit.Characters;
    public bool IsWords => Units == CharacterCountMaxLengthUnit.Words;

    public CharacterCountLimitViewModel(int limit, CharacterCountMaxLengthUnit units)
    {
        Limit = limit;
        Units = units;
    }
}

public enum CharacterCountMaxLengthUnit
{
    Characters,
    Words
}