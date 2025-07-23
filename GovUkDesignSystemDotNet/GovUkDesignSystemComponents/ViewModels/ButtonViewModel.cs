namespace GovUkDesignSystemDotNet;

public class ButtonViewModel
{
    [Obsolete]
    public ButtonElementType? Element { get; set; }
    public HtmlOrText HtmlOrText { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Value { get; set; }
    public bool Disabled { get; set; }
    public string Href { get; set; }
    public List<string> Classes { get; set; } = [];
    public Dictionary<string, string> Attributes { get; set; }
    public bool PreventDoubleClick { get; set; }
    public bool IsStartButton { get; set; }
    public string Id { get; set; }
}

public enum ButtonElementType
{
    Input,
    Button,
    A
}