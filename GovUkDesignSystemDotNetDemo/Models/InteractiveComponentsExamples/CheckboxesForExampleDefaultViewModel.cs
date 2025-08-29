using GovUkDesignSystemDotNet;

namespace GovUkDesignSystemDotNetDemo.Models.InteractiveComponentsExamples;

public class CheckboxesForExampleDefaultViewModel
{
    [GovUkValidateCheckboxNumberOfResponsesRange(ErrorMessageIfNothingSelected = "Please select how we should contact you")]
    public List<ContactMethods> HowShouldWeContactYou { get; set; } = [];

    [GovUkValidateRequiredIf(IsRequiredPropertyName = nameof(EmailAddressRequired), ErrorMessageIfMissing = "Enter your email address")]
    public string EmailAddress { get; set; }

    public bool EmailAddressRequired => HowShouldWeContactYou.Contains(ContactMethods.Email);

    [GovUkValidateRequiredIf(IsRequiredPropertyName = nameof(PhoneNumberRequired), ErrorMessageIfMissing = "Enter your phone number")]
    public string PhoneNumber { get; set; }

    public bool PhoneNumberRequired => HowShouldWeContactYou.Contains(ContactMethods.TextMessage);
}

public enum ContactMethods
{
    Email,
    
    [GovUkRadioCheckboxLabelText(Text = "Text message")]
    TextMessage,
    
    [GovUkRadioCheckboxLabelText(Text = "I don't want to be contacted")]
    NoContact,
}
