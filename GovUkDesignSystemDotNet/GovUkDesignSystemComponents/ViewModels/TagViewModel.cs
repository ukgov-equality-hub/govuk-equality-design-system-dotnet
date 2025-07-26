namespace GovUkDesignSystemDotNet;

public class TagViewModel
{
    public HtmlOrText HtmlOrText { get; set; }
    public List<string> Classes { get; set; } = [];
    public Dictionary<string, string> Attributes { get; set; }
}
