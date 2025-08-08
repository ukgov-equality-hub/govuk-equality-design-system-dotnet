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

    public static async Task<IHtmlContent> GovUkCharacterCount(
        this IHtmlHelper htmlHelper,
        CharacterCountViewModel characterCountViewModel)
    {
        return await htmlHelper.PartialAsync("/GovUkDesignSystemComponents/Views/CharacterCount.cshtml", characterCountViewModel);
    }

    public static async Task<IHtmlContent> GovUkCheckboxItem(
        this IHtmlHelper htmlHelper,
        CheckboxItemViewModel checkboxItemViewModel)
    {
        return await htmlHelper.PartialAsync("/GovUkDesignSystemComponents/Views/CheckboxItem.cshtml", checkboxItemViewModel);
    }

    public static async Task<IHtmlContent> GovUkCheckboxes(
        this IHtmlHelper htmlHelper,
        CheckboxesViewModel checkboxesViewModel)
    {
        return await htmlHelper.PartialAsync("/GovUkDesignSystemComponents/Views/Checkboxes.cshtml", checkboxesViewModel);
    }

    public static async Task<IHtmlContent> GovUkErrorMessage(
        this IHtmlHelper htmlHelper,
        ErrorMessageViewModel errorMessageViewModel)
    {
        return await htmlHelper.PartialAsync("/GovUkDesignSystemComponents/Views/ErrorMessage.cshtml", errorMessageViewModel);
    }

    public static async Task<IHtmlContent> GovUkErrorSummary(
        this IHtmlHelper htmlHelper,
        ErrorSummaryViewModel errorSummaryViewModel)
    {
        return await htmlHelper.PartialAsync("/GovUkDesignSystemComponents/Views/ErrorSummary.cshtml", errorSummaryViewModel);
    }

    public static async Task<IHtmlContent> GovUkFieldset(
        this IHtmlHelper htmlHelper,
        FieldsetViewModel fieldsetViewModel)
    {
        return await htmlHelper.PartialAsync("/GovUkDesignSystemComponents/Views/Fieldset.cshtml", fieldsetViewModel);
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

    public static async Task<IHtmlContent> GovUkRadioItem(
        this IHtmlHelper htmlHelper,
        RadioItemViewModel radioItemViewModel)
    {
        return await htmlHelper.PartialAsync("/GovUkDesignSystemComponents/Views/RadioItem.cshtml", radioItemViewModel);
    }

    public static async Task<IHtmlContent> GovUkRadios(
        this IHtmlHelper htmlHelper,
        RadiosViewModel radiosViewModel)
    {
        return await htmlHelper.PartialAsync("/GovUkDesignSystemComponents/Views/Radios.cshtml", radiosViewModel);
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

    public static async Task<IHtmlContent> GovUkTextarea(
        this IHtmlHelper htmlHelper,
        TextareaViewModel textareaViewModel)
    {
        return await htmlHelper.PartialAsync("/GovUkDesignSystemComponents/Views/Textarea.cshtml", textareaViewModel);
    }

    public static async Task<IHtmlContent> GovUkTextInput(
        this IHtmlHelper htmlHelper,
        TextInputViewModel textInputViewModel)
    {
        return await htmlHelper.PartialAsync("/GovUkDesignSystemComponents/Views/TextInput.cshtml", textInputViewModel);
    }

}