namespace GovUkDesignSystemDotNet;

public class TextInputViewModel : IHasErrorMessage
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string InputMode { get; set; }
    public string Value { get; set; }
    public bool Disabled { get; set; }
    public List<string> DescribedBy { get; set; } = [];
    public LabelViewModel Label { get; set; }
    public HintViewModel Hint { get; set; }
    public ErrorMessageViewModel ErrorMessage { get; set; }
    public TextInputPrefixSuffixViewModel Prefix { get; set; }
    public TextInputPrefixSuffixViewModel Suffix { get; set; }
    public FormGroupViewModel FormGroup { get; set; }
    public List<string> Classes { get; set; } = [];
    public string Autocomplete { get; set; }
    public string Pattern { get; set; }
    public bool? Spellcheck { get; set; }
    public string Autocapitalize { get; set; }
    public TextInputWrapperViewModel InputWrapper { get; set; }
    public Dictionary<string, string> Attributes { get; set; }
}

public class TextInputPrefixSuffixViewModel
{
    public HtmlOrText HtmlOrText { get; set; }
    public List<string> Classes { get; set; } = [];
    public Dictionary<string, string> Attributes { get; set; }
}

public class TextInputWrapperViewModel
{
    public List<string> Classes { get; set; } = [];
    public Dictionary<string, string> Attributes { get; set; }
}
