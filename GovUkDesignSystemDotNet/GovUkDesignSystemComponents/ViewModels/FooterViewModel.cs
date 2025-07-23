namespace GovUkDesignSystemDotNet;

public class FooterViewModel
{
    public FooterMetaViewModel Meta { get; set; }
    public List<FooterNavigationSectionViewModel> NavigationSections { get; set; } = [];
    public HtmlOrText ContentLicence { get; set; }
    public HtmlOrText Copyright { get; set; }
    public List<string> ContainerClasses { get; set; } = [];
    public List<string> Classes { get; set; } = [];
    public Dictionary<string, string> Attributes { get; set; }
}

public class FooterMetaViewModel {
    public string VisuallyHiddenTitle { get; set; }
    public HtmlOrText HtmlOrText { get; set; }
    public List<FooterItemViewModel> Items { get; set; } = [];
}

public class FooterNavigationSectionViewModel {
    public string Title { get; set; }
    public int? Columns { get; set; }
    public string Width { get; set; }
    public List<FooterItemViewModel> Items { get; set; } = [];
}

public class FooterItemViewModel {
    public string Text { get; set; }
    public string Href { get; set; }
    public Dictionary<string, string> Attributes { get; set; }
}
