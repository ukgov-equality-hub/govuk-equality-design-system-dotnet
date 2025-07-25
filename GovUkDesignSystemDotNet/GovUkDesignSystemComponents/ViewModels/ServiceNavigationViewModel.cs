namespace GovUkDesignSystemDotNet;

public class ServiceNavigationViewModel
{
    public List<string> Classes { get; set; } = [];
    public Dictionary<string, string> Attributes { get; set; }
    public string AriaLabel { get; set; }
    public string MenuButtonText { get; set; }
    public string MenuButtonLabel { get; set; }
    public string NavigationLabel { get; set; }
    public string NavigationId { get; set; }
    public List<string> NavigationClasses { get; set; } = [];
    public bool? CollapseNavigationOnMobile { get; set; }
    public string ServiceName { get; set; }
    public string ServiceUrl { get; set; }
    public List<ServiceNavigationItemViewModel> NavigationItems { get; set; } = [];
    public ServiceNavigationSlotsViewModel Slots { get; set; }
}

public class ServiceNavigationItemViewModel
{
    public bool Current { get; set; }
    public bool Active { get; set; }
    public HtmlOrText HtmlOrText { get; set; }
    public string Href { get; set; }
    public Dictionary<string, string> Attributes { get; set; }
}

public class ServiceNavigationSlotsViewModel
{
    public HtmlOrText Start { get; set; }
    public HtmlOrText End { get; set; }
    public HtmlOrText NavigationStart { get; set; }
    public HtmlOrText NavigationEnd { get; set; }
}
