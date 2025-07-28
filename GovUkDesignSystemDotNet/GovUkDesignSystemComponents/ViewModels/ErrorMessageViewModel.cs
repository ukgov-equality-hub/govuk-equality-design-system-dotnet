namespace GovUkDesignSystemDotNet;

public class ErrorMessageViewModel
{
    public HtmlOrText HtmlOrText { get; set; }
    public string Id { get; set; }
    public List<string> Classes { get; set; } = [];
    public Dictionary<string, string> Attributes { get; set; }
    public string VisuallyHiddenText { get; set; }
}
