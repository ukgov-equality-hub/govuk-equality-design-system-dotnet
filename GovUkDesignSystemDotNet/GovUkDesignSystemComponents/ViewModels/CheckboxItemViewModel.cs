namespace GovUkDesignSystemDotNet;

public class CheckboxItemViewModel
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }
    public LabelViewModel Label { get; set; }
    public HintViewModel Hint { get; set; }
    public string Divider { get; set; }
    public bool Checked { get; set; }
    public HtmlOrText Conditional { get; set; }
    public bool Exclusive { get; set; }
    public bool Disabled { get; set; }
    public List<string> DescribedBy { get; set; } = [];
    public Dictionary<string, string> Attributes { get; set; }
}
