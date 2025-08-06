namespace GovUkDesignSystemDotNet;

public class ErrorSummaryViewModel
{
    public HtmlOrText Title { get; set; }
    public HtmlOrText Description { get; set; }
    public List<ErrorSummaryItemViewModel> Errors { get; set; } = [];
    public bool DisableAutoFocus { get; set; }
    public List<string> Classes { get; set; } = [];
    public Dictionary<string, string> Attributes { get; set; }
}

public class ErrorSummaryItemViewModel
{
    public string Href { get; set; }
    public HtmlOrText HtmlOrText { get; set; }
    public Dictionary<string, string> Attributes { get; set; }
}
