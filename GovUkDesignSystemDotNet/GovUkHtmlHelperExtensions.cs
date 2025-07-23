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

}