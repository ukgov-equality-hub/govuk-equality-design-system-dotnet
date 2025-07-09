namespace GovUkDesignSystemDotNet;

public class BreadcrumbsViewModel
{
    public List<CrumbViewModel> Crumbs { get; set; }
    public string Classes { get; set; }
    public bool CollapseOnMobile { get; set; }
    public Dictionary<string, string> Attributes { get; set; }
    public string LabelText { get; set; }
}

public class CrumbViewModel
{
    public HtmlOrText HtmlOrText { get; set; }
    public string Href { get; set; }
    public Dictionary<string, string> Attributes { get; set; }
}
