namespace GovUkDesignSystemDotNet;

public class FormGroupViewModel
{
    public List<string> Classes { get; set; } = [];
    public Dictionary<string, string> Attributes { get; set; }
    public HtmlOrText BeforeInput { get; set; }
    public HtmlOrText AfterInput { get; set; }
}
