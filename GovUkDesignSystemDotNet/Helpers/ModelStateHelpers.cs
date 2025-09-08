using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GovUkDesignSystemDotNet.Helpers;

internal static class ModelStateHelpers
{
    /// <summary>
    /// Get the value to put in the input from the post data if possible, otherwise use the value in the model
    /// </summary>
    internal static string GetStringValueFromModelStateOrModel<TModel, TProperty>(
        ModelStateEntry modelStateEntry,
        TModel model,
        Expression<Func<TModel, TProperty>> propertyExpression)
        where TModel : class
    {
        if (modelStateEntry != null && modelStateEntry.RawValue != null)
        {
            string inputValue = modelStateEntry.RawValue as string;
            return inputValue;
        }

        var modelValue = ExpressionHelpers.GetPropertyValueFromModelAndExpression(model, propertyExpression);
        if (modelValue != null)
        {
            string inputValue = modelValue.ToString();
            return inputValue;
        }

        return null;
    }

    /// <summary>
    /// Get the value to put in the input from the post data if possible, otherwise use the value in the model
    /// </summary>
    public static TEnum? GetNullableEnumValueFromModelStateOrModel<TModel, TEnum>(
        ModelStateEntry modelStateEntry,
        TModel model,
        Expression<Func<TModel, TEnum?>> propertyExpression)
        where TModel : class
        where TEnum : struct, Enum
    {
        if (modelStateEntry != null && modelStateEntry.RawValue != null)
        {
            return (TEnum)Enum.Parse(typeof(TEnum), modelStateEntry.RawValue.ToString());
        }
        else
        {
            return ExpressionHelpers.GetPropertyValueFromModelAndExpression(model, propertyExpression);
        }
    }

    /// <summary>
    /// Get the value to put in the input from the post data if possible, otherwise use the value in the model
    /// </summary>
    public static List<TEnum> GetListOfEnumValuesFromModelStateOrModel<TModel, TEnum>(
        ModelStateEntry modelStateEntry,
        TModel model,
        Expression<Func<TModel, List<TEnum>>> propertyLambdaExpression
        )
        where TModel : class
        where TEnum : struct, Enum
    {
        if (modelStateEntry != null && modelStateEntry.RawValue != null)
        {
            var stringValues = new List<string>();
            if (modelStateEntry.RawValue is string[] rawValueStrings)
            {
                stringValues.AddRange(rawValueStrings);
            }
            else if (modelStateEntry.RawValue is string rawValueString)
            {
                stringValues.Add(rawValueString);
            }

            return stringValues
                .Where(e => Enum.TryParse<TEnum>(e, out _))
                .Select(e => Enum.Parse<TEnum>(e))
                .ToList();
        }

        return ExpressionHelpers.GetPropertyValueFromModelAndExpression(model, propertyLambdaExpression);
    }

    /// <summary>
    /// Get the value to put in the input from the post data if possible, otherwise use the value in the model
    /// </summary>
    public static List<string> GetListOfStringValuesFromModelStateOrModel<TModel>(
        ModelStateEntry modelStateEntry,
        TModel model,
        Expression<Func<TModel, List<string>>> propertyLambdaExpression)
        where TModel : class
    {
        if (modelStateEntry != null && modelStateEntry.RawValue != null)
        {
            if (modelStateEntry.RawValue is string[] rawValueStrings)
            {
                return rawValueStrings.ToList();
            }

            if (modelStateEntry.RawValue is string rawValueString)
            {
                return [rawValueString];
            }
            
            return [];
        }

        return ExpressionHelpers.GetPropertyValueFromModelAndExpression(model, propertyLambdaExpression);
    }

    /// <summary>
    /// Get the value to put in the input from the post data if possible, otherwise use the value in the model
    /// </summary>
    public static bool GetCheckboxBoolValueFromModelStateOrModel<TModel>(
        ModelStateEntry modelStateEntry,
        TModel model,
        Expression<Func<TModel, bool>> propertyLambdaExpression)
        where TModel : class
    {
        if (modelStateEntry != null && modelStateEntry.RawValue != null)
        {
            var values = new List<string>();
            if (modelStateEntry.RawValue is string[])
            {
                values.AddRange((string[])modelStateEntry.RawValue);
            }
            else if (modelStateEntry.RawValue is string)
            {
                values.Add((string)modelStateEntry.RawValue);
            }
            var boolValues = values.Select(v => bool.Parse(v));

            // If there are multiple values accept any "true" value
            return boolValues.Any(bv => bv);
        }

        return ExpressionHelpers.GetPropertyValueFromModelAndExpression(model, propertyLambdaExpression);
    }
    
    /// <summary>
    /// If modelStateEntry contains any errors add them to target
    /// </summary>
    public static ErrorMessageViewModel GetErrorMessages(ModelStateEntry modelStateEntry)
    {
        if (modelStateEntry != null && modelStateEntry.Errors.Count > 0)
        {
            string errorMessagesText = string.Join(", ", modelStateEntry.Errors.Select(e => e.ErrorMessage));

            return new ErrorMessageViewModel
            {
                HtmlOrText = new HtmlOrText(errorMessagesText)
            };
        }
        
        return null;
    }
    
}
