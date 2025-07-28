namespace GovUkDesignSystemDotNet;

public class HintViewModel
{
    public HtmlOrText HtmlOrText { get; set; }
    public string Id { get; set; }
    public List<string> Classes { get; set; } = [];
    public Dictionary<string, string> Attributes { get; set; }
}
