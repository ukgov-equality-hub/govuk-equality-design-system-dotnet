using System.Linq.Expressions;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GovUkDesignSystemDotNet.Helpers;

internal static class InteractiveComponentsHelper
{
    internal static void PopulateViewModelForCharacterCount<TModel, TProperty>(
        IHtmlHelper<TModel> htmlHelper,
        Expression<Func<TModel, TProperty>> propertyExpression,
        CharacterCountViewModel viewModel)
        where TModel : class
    {
        viewModel.Id ??= htmlHelper.IdFor(propertyExpression);
        viewModel.Name ??= htmlHelper.NameFor(propertyExpression);
        
        if (viewModel.Limit == null)
        {
            PropertyInfo property = ExpressionHelpers.GetPropertyFromExpression(propertyExpression);
            var attribute = AttributesHelper.GetSingleCustomAttribute<GovUkValidateCharacterCountAttribute>(property);
            if (attribute == null)
            {
                throw new ArgumentException(
                    "GovUkCharacterCountFor can only be used on properties that are decorated with a GovUkValidateCharacterCount attribute. "
                    + $"Property [{property.Name}] on type [{property.DeclaringType.FullName}] does not have this attribute");
            }

            viewModel.Limit = new CharacterCountLimitViewModel(attribute.Limit, attribute.Units);
        }
        
        htmlHelper.ViewData.ModelState.TryGetValue(viewModel.Name, out ModelStateEntry modelStateEntry);
        
        viewModel.Value ??= ModelStateHelpers.GetStringValueFromModelStateOrModel(modelStateEntry, htmlHelper.ViewData.Model, propertyExpression);
        
        viewModel.ErrorMessage = ModelStateHelpers.GetErrorMessages(modelStateEntry);
    }
    
    internal static void PopulateViewModelForTextarea<TModel, TProperty>(
        IHtmlHelper<TModel> htmlHelper,
        Expression<Func<TModel, TProperty>> propertyExpression,
        TextareaViewModel viewModel)
        where TModel : class
    {
        viewModel.Id ??= htmlHelper.IdFor(propertyExpression);
        viewModel.Name ??= htmlHelper.NameFor(propertyExpression);
        
        htmlHelper.ViewData.ModelState.TryGetValue(viewModel.Name, out ModelStateEntry modelStateEntry);
        
        viewModel.Value ??= ModelStateHelpers.GetStringValueFromModelStateOrModel(modelStateEntry, htmlHelper.ViewData.Model, propertyExpression);
        
        viewModel.ErrorMessage = ModelStateHelpers.GetErrorMessages(modelStateEntry);
    }
    
    internal static void PopulateViewModelForTextInput<TModel, TProperty>(
        IHtmlHelper<TModel> htmlHelper,
        Expression<Func<TModel, TProperty>> propertyExpression,
        TextInputViewModel viewModel)
        where TModel : class
    {
        viewModel.Id ??= htmlHelper.IdFor(propertyExpression);
        viewModel.Name ??= htmlHelper.NameFor(propertyExpression);
        
        htmlHelper.ViewData.ModelState.TryGetValue(viewModel.Name, out ModelStateEntry modelStateEntry);
        
        viewModel.Value ??= ModelStateHelpers.GetStringValueFromModelStateOrModel(modelStateEntry, htmlHelper.ViewData.Model, propertyExpression);
        
        viewModel.ErrorMessage = ModelStateHelpers.GetErrorMessages(modelStateEntry);
    }
}
