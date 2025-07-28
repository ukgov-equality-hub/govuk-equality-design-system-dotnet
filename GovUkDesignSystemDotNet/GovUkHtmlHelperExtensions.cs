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

    public static async Task<IHtmlContent> GovUkErrorMessage(
        this IHtmlHelper htmlHelper,
        ErrorMessageViewModel errorMessageViewModel)
    {
        return await htmlHelper.PartialAsync("/GovUkDesignSystemComponents/Views/ErrorMessage.cshtml", errorMessageViewModel);
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

    public static async Task<IHtmlContent> GovUkHint(
        this IHtmlHelper htmlHelper,
        HintViewModel hintViewModel)
    {
        return await htmlHelper.PartialAsync("/GovUkDesignSystemComponents/Views/Hint.cshtml", hintViewModel);
    }

    public static async Task<IHtmlContent> GovUkLabel(
        this IHtmlHelper htmlHelper,
        LabelViewModel labelViewModel)
    {
        return await htmlHelper.PartialAsync("/GovUkDesignSystemComponents/Views/Label.cshtml", labelViewModel);
    }

    public static async Task<IHtmlContent> GovUkPhaseBanner(
        this IHtmlHelper htmlHelper,
        PhaseBannerViewModel phaseBannerViewModel)
    {
        return await htmlHelper.PartialAsync("/GovUkDesignSystemComponents/Views/PhaseBanner.cshtml", phaseBannerViewModel);
    }

    public static async Task<IHtmlContent> GovUkServiceNavigation(
        this IHtmlHelper htmlHelper,
        ServiceNavigationViewModel serviceNavigationViewModel)
    {
        return await htmlHelper.PartialAsync("/GovUkDesignSystemComponents/Views/ServiceNavigation.cshtml", serviceNavigationViewModel);
    }

    public static async Task<IHtmlContent> GovUkTag(
        this IHtmlHelper htmlHelper,
        TagViewModel tagViewModel)
    {
        return await htmlHelper.PartialAsync("/GovUkDesignSystemComponents/Views/Tag.cshtml", tagViewModel);
    }

}