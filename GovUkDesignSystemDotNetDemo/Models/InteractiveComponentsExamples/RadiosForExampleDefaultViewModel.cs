using GovUkDesignSystemDotNet;

namespace GovUkDesignSystemDotNetDemo.Models.InteractiveComponentsExamples;

public class RadiosForExampleDefaultViewModel
{
    [GovUkValidateRequired(ErrorMessageIfMissing = "Please select a country")]
    public WhereDoYouLiveCountries? WhereDoYouLive { get; set; }

    [GovUkValidateRequiredIf(IsRequiredPropertyName = nameof(OtherCountryRequired), ErrorMessageIfMissing = "Enter the name of the country")]
    public string OtherCountry { get; set; }

    public bool OtherCountryRequired => WhereDoYouLive == WhereDoYouLiveCountries.AnotherCountry;
}

public enum WhereDoYouLiveCountries
{
    England,
    Scotland,
    Wales,
    
    [GovUkRadioCheckboxLabelText(Text = "Northern Ireland")]
    NorthernIreland,
    
    [GovUkRadioCheckboxLabelText(Text = "Another country")]
    AnotherCountry,
}
