namespace GovUkDesignSystemDotNet;

public class PhaseBannerViewModel
{
    public HtmlOrText HtmlOrText { get; set; }
    public TagViewModel Tag { get; set; }
    public List<string> Classes { get; set; } = [];
    public Dictionary<string, string> Attributes { get; set; }
}
