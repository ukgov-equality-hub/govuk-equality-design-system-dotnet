namespace GovUkDesignSystemDotNetDemo.Models;

public class InteractiveExampleViewModel
{
    public string ExampleHref { get; set; }
    public List<InteractiveExampleCodeSnippetViewModel> CodeSnippets { get; set; } = [];
}

public class InteractiveExampleCodeSnippetViewModel
{
    public string Title { get; set; }
    public string Filename { get; set; }
    public string Code { get; set; }
}