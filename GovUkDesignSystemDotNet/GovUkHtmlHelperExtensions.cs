using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GovUkDesignSystemDotNet;

public static class GovUkHtmlHelperExtensions
{
    
    public static async Task<IHtmlContent> GovUkBackLink(
        this IHtmlHelper htmlHelper,
        BackLinkViewModel backLinkViewModel)
    {
        return await htmlHelper.PartialAsync("/GovUkDesignSystemComponents/Views/BackLink.cshtml", backLinkViewModel);
    }

    public static async Task<IHtmlContent> GovUkBreadcrumbs(
        this IHtmlHelper htmlHelper,
        BreadcrumbsViewModel breadcrumbsViewModel)
    {
        return await htmlHelper.PartialAsync("/GovUkDesignSystemComponents/Views/Breadcrumbs.cshtml", breadcrumbsViewModel);
    }

    public static async Task<IHtmlContent> GovUkButton(
        this IHtmlHelper htmlHelper,
        ButtonViewModel buttonViewModel)
    {
        return await htmlHelper.PartialAsync("/GovUkDesignSystemComponents/Views/Button.cshtml", buttonViewModel);
    }

    public static async Task<IHtmlContent> GovUkFooter(
        this IHtmlHelper htmlHelper,
        FooterViewModel footerViewModel)
    {
        return await htmlHelper.PartialAsync("/GovUkDesignSystemComponents/Views/Footer.cshtml", footerViewModel);
    }

    public static async Task<IHtmlContent> GovUkHeader(
        this IHtmlHelper htmlHelper,
        HeaderViewModel headerViewModel)
    {
        return await htmlHelper.PartialAsync("/GovUkDesignSystemComponents/Views/Header.cshtml", headerViewModel);
    }

    public static async Task<IHtmlContent> GovUkServiceNavigation(
        this IHtmlHelper htmlHelper,
        ServiceNavigationViewModel serviceNavigationViewModel)
    {
        return await htmlHelper.PartialAsync("/GovUkDesignSystemComponents/Views/ServiceNavigation.cshtml", serviceNavigationViewModel);
    }

}