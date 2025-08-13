namespace GovUkDesignSystemDotNet;

public class TextareaViewModel : IHasErrorMessage
{
    public string Id { get; set; }
    public string Name { get; set; }
    public bool? Spellcheck { get; set; }
    public int? Rows { get; set; }
    public string Value { get; set; }
    public bool Disabled { get; set; }
    public List<string> DescribedBy { get; set; } = [];
    public LabelViewModel Label { get; set; }
    public HintViewModel Hint { get; set; }
    public ErrorMessageViewModel ErrorMessage { get; set; }
    public FormGroupViewModel FormGroup { get; set; }
    public List<string> Classes { get; set; } = [];
    public string Autocomplete { get; set; }
    public Dictionary<string, string> Attributes { get; set; }
}
