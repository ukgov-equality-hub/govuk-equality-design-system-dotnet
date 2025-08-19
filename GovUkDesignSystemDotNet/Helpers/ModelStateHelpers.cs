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
