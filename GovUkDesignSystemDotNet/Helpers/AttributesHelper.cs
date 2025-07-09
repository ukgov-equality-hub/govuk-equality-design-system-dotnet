using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GovUkDesignSystemDotNet.Helpers;

public static class AttributesHelper
{
    public static IHtmlContent ToHtmlTagAttributes(
        this Dictionary<string, string> attributesDictionary,
        IHtmlHelper html)
    {
        string attributesString;
        if (attributesDictionary == null)
        {
            attributesString = "";
        }
        else
        {
            var attributeStrings = attributesDictionary.Select(kv => kv.Value == null ? kv.Key : $"{kv.Key}=\"{kv.Value}\"");
            attributesString = string.Join(" ", attributeStrings);
        }

        return html.Raw(attributesString);
    }
}
