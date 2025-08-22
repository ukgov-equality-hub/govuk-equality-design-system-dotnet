using System.ComponentModel.DataAnnotations;

namespace GovUkDesignSystemDotNet;

[AttributeUsage(AttributeTargets.Property)]
public class GovUkValidateCharacterCountAttribute : ValidationAttribute
{
    public int Limit { get; init; }
    public CharacterCountMaxLengthUnit Units { get; init; }

    /// <summary>
    /// Whether a value must be supplied
    /// </summary>
    public bool IsRequired { get; init; } = false;

    /// <summary>
    /// The name as it would appear at the start of a sentence
    /// <br/>e.g. "[Full name] must be 2 characters or more"
    /// <br/>e.g. "[Median age] must be a number"
    /// </summary>
    public string NameAtStartOfSentence { get; init; }

    /// <summary>
    /// The name as it would appear within / at the end of a sentence
    /// <br/>e.g. "Enter [your full name]"
    /// <br/>or "Enter [the median age]"
    /// </summary>
    public string NameWithinSentence { get; init; }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (string.IsNullOrEmpty(NameAtStartOfSentence))
        {
            throw new ArgumentNullException("NameAtStartOfSentence cannot be null or empty");
        }
        if (string.IsNullOrEmpty(NameWithinSentence))
        {
            throw new ArgumentNullException("NameWithinSentence cannot be null or empty");
        }

        var stringValue = (string)value;

        if (IsRequired &&
            string.IsNullOrEmpty(stringValue))
        {
            return new ValidationResult($"Enter {NameWithinSentence}");
        }

        if (stringValue != null && IsOverLimit(stringValue))
        {
            string error = $"{NameAtStartOfSentence} must be {Limit} {(Units == CharacterCountMaxLengthUnit.Characters ? "characters" : "words")} or fewer";
            return new ValidationResult(error);
        }

        return ValidationResult.Success;
    }

    private bool IsOverLimit(string value)
    {
        switch (Units)
        {
            case CharacterCountMaxLengthUnit.Characters:
                return value.Length > Limit;
            case CharacterCountMaxLengthUnit.Words:
                return value.Split([' ', '\r', '\n', '\t'], StringSplitOptions.RemoveEmptyEntries).Length > Limit;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}