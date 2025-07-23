namespace GovUkDesignSystemDotNet;

public class BackLinkViewModel
{
    public HtmlOrText HtmlOrText { get; set; }
    public string Href { get; set; }
    public bool OverrideWithJavascript { get; set; }
    public List<string> Classes { get; set; } = [];
    public Dictionary<string, string> Attributes { get; set; }
}
