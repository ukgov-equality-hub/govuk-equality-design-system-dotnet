namespace GovUkDesignSystemDotNet;

public class HtmlOrText
{
    public Func<object, object> Html { get; }
    public string Text { get; }

    public bool HasHtml => Html != null;
    public bool HasText => Text != null;
    public object Value => HasHtml ? Html(new object()) : Text;

    public HtmlOrText(Func<object, object> html)
    {
        Html = html;
    }

    public HtmlOrText(string text)
    {
        Text = text;
    }
}
