namespace GovUkDesignSystemDotNet;

public class LabelViewModel
{
    public HtmlOrText HtmlOrText { get; set; }
    public string For { get; set; }
    public bool IsPageHeading { get; set; }
    public List<string> Classes { get; set; } = [];
    public Dictionary<string, string> Attributes { get; set; }
}
