namespace GovUkDesignSystemDotNet;

public class HeaderViewModel
{
    public string HomepageUrl { get; set; }
    public string ProductName { get; set; }
    public List<string> ContainerClasses { get; set; } = [];
    public List<string> Classes { get; set; } = [];
    public Dictionary<string, string> Attributes { get; set; }
}
