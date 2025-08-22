using System.Reflection;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

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

    public static void AddI18nAttribute(
        this Dictionary<string, string> attributesDictionary,
        string key,
        string message)
    {
        if (!string.IsNullOrWhiteSpace(message))
        {
            attributesDictionary.Add($"data-i18n.{key}", message);
        }
    }
    
    public static void AddI18nAttributes(
        this Dictionary<string, string> attributesDictionary,
        string key,
        PluralisationOptions messages)
    {
        if (messages != null)
        {
            AddI18nAttribute(attributesDictionary, $"data-i18n.{key}.zero", messages.Zero);
            AddI18nAttribute(attributesDictionary, $"data-i18n.{key}.one", messages.One);
            AddI18nAttribute(attributesDictionary, $"data-i18n.{key}.two", messages.Two);
            AddI18nAttribute(attributesDictionary, $"data-i18n.{key}.few", messages.Few);
            AddI18nAttribute(attributesDictionary, $"data-i18n.{key}.many", messages.Many);
            AddI18nAttribute(attributesDictionary, $"data-i18n.{key}.other", messages.Other);
        }
    }
    
    public static TAttributeType GetSingleCustomAttribute<TAttributeType>(MemberInfo property)
        where TAttributeType : Attribute
    {
        return property.GetCustomAttributes(typeof(TAttributeType)).SingleOrDefault() as TAttributeType;
    }
}
