namespace GovUkDesignSystemDotNet;

public class FieldsetViewModel
{
    public List<string> DescribedBy { get; set; } = [];
    public FieldsetLegendViewModel Legend { get; set; }
    public List<string> Classes { get; set; } = [];
    public string Role { get; set; }
    public Dictionary<string, string> Attributes { get; set; }
    public HtmlOrText HtmlOrText { get; set; }
}

public class FieldsetLegendViewModel
{
    public HtmlOrText HtmlOrText { get; set; }
    public List<string> Classes { get; set; } = [];
    public bool IsPageHeading { get; set; }
}
