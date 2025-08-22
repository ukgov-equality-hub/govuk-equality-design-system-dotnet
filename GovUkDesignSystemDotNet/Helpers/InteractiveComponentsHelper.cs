﻿using System.Linq.Expressions;
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

    public static void PopulateViewModelForErrorSummary(
        ModelStateDictionary modelState,
        List<string> optionalOrderOfPropertyNamesInTheView,
        ref ErrorSummaryViewModel viewModel)
    {
        optionalOrderOfPropertyNamesInTheView ??= [];
        viewModel ??= new ErrorSummaryViewModel();
        
        viewModel.Title ??= new HtmlOrText("There is a problem");

        var propertiesWithErrors = modelState
            .Where(mseKvp => mseKvp.Value.Errors.Any())
            .ToList();

        var orderedPropertiesWithErrors = propertiesWithErrors
            .Where(mseKvp => optionalOrderOfPropertyNamesInTheView.Contains(mseKvp.Key))
            .OrderBy(mseKvp => optionalOrderOfPropertyNamesInTheView.IndexOf(mseKvp.Key));

        var unorderedPropertiesWithErrors = propertiesWithErrors
            .Where(mseKvp => !optionalOrderOfPropertyNamesInTheView.Contains(mseKvp.Key));

        var reorderedPropertiesWithErrors = orderedPropertiesWithErrors.Concat(unorderedPropertiesWithErrors);

        foreach (KeyValuePair<string,ModelStateEntry> mseKvp in reorderedPropertiesWithErrors)
        {
            foreach (ModelError modelError in mseKvp.Value.Errors)
            {
                viewModel.Errors.Add(new ErrorSummaryItemViewModel
                {
                    Href = $"#{mseKvp.Key}",
                    HtmlOrText = new HtmlOrText(modelError.ErrorMessage)
                });
            }
        }
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
