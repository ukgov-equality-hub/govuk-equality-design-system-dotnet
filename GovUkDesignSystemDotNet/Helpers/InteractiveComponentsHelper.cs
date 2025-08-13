using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GovUkDesignSystemDotNet.Helpers;

internal static class InteractiveComponentsHelper
{
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
