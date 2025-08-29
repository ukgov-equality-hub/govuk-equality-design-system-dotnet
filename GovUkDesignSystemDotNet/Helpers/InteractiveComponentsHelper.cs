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
    
    internal static void PopulateViewModelForCheckboxes<TModel, TEnum>(
        IHtmlHelper<TModel> htmlHelper,
        Expression<Func<TModel, List<TEnum>>> propertyExpression,
        CheckboxesViewModel viewModel,
        Dictionary<TEnum, CheckboxItemViewModel> checkboxItemViewModels = null,
        Dictionary<TEnum, string> dividersBefore = null,
        IEnumerable<TEnum> overrideEnumValues = null)
        where TModel : class
        where TEnum : struct, Enum
    {
        viewModel.Name ??= htmlHelper.NameFor(propertyExpression);
        
        htmlHelper.ViewData.ModelState.TryGetValue(viewModel.Name, out ModelStateEntry modelStateEntry);
        
        viewModel.CheckboxItems ??= [];
        if (viewModel.CheckboxItems.Count == 0)
        {
            List<TEnum> selectedValues = ModelStateHelpers.GetListOfEnumValuesFromModelStateOrModel(modelStateEntry, htmlHelper.ViewData.Model, propertyExpression);
            IEnumerable<TEnum> enumOptions = overrideEnumValues ?? Enum.GetValues(typeof(TEnum)).Cast<TEnum>();

            foreach (TEnum enumOption in enumOptions)
            {
                if (dividersBefore != null && dividersBefore.TryGetValue(enumOption, out var dividerContent))
                {
                    viewModel.CheckboxItems.Add(new CheckboxItemViewModel
                    {
                        Divider = dividerContent,
                    });
                }

                CheckboxItemViewModel checkboxItemViewModel = checkboxItemViewModels != null && checkboxItemViewModels.ContainsKey(enumOption)
                    ? checkboxItemViewModels[enumOption]
                    : new CheckboxItemViewModel();
                
                checkboxItemViewModel.Value ??= enumOption.ToString();
                checkboxItemViewModel.Checked = selectedValues.Contains(enumOption);
                
                checkboxItemViewModel.Label ??= new LabelViewModel
                {
                    HtmlOrText = new HtmlOrText(GovUkRadioCheckboxLabelTextAttribute.GetLabelText(enumOption)),
                };
                
                viewModel.CheckboxItems.Add(checkboxItemViewModel);
            }
        }

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
    
    internal static void PopulateViewModelForFileUpload<TModel, TProperty>(
        IHtmlHelper<TModel> htmlHelper,
        Expression<Func<TModel, TProperty>> propertyExpression,
        FileUploadViewModel viewModel)
        where TModel : class
    {
        viewModel.Id ??= htmlHelper.IdFor(propertyExpression);
        viewModel.Name ??= htmlHelper.NameFor(propertyExpression);
        
        htmlHelper.ViewData.ModelState.TryGetValue(viewModel.Name, out ModelStateEntry modelStateEntry);
        
        viewModel.ErrorMessage = ModelStateHelpers.GetErrorMessages(modelStateEntry);
    }
    
    internal static void PopulateViewModelForRadios<TModel, TEnum>(
        IHtmlHelper<TModel> htmlHelper,
        Expression<Func<TModel, TEnum?>> propertyExpression,
        RadiosViewModel viewModel,
        Dictionary<TEnum, RadioItemViewModel> radioItemViewModels = null,
        Dictionary<TEnum, string> dividersBefore = null,
        IEnumerable<TEnum> overrideEnumValues = null)
        where TModel : class
        where TEnum : struct, Enum
    {
        viewModel.Name ??= htmlHelper.NameFor(propertyExpression);
        
        htmlHelper.ViewData.ModelState.TryGetValue(viewModel.Name, out ModelStateEntry modelStateEntry);
        
        viewModel.RadioItems ??= [];
        if (viewModel.RadioItems.Count == 0)
        {
            TEnum? selectedValue = ModelStateHelpers.GetNullableEnumValueFromModelStateOrModel(modelStateEntry, htmlHelper.ViewData.Model, propertyExpression);
            IEnumerable<TEnum> enumOptions = overrideEnumValues ?? Enum.GetValues(typeof(TEnum)).Cast<TEnum>();

            foreach (TEnum enumOption in enumOptions)
            {
                if (dividersBefore != null && dividersBefore.ContainsKey(enumOption))
                {
                    viewModel.RadioItems.Add(new RadioItemViewModel
                    {
                        Divider = dividersBefore[enumOption],
                    });
                }

                RadioItemViewModel radioItemViewModel = radioItemViewModels != null && radioItemViewModels.ContainsKey(enumOption)
                    ? radioItemViewModels[enumOption]
                    : new RadioItemViewModel();
                
                radioItemViewModel.Value ??= enumOption.ToString();
                radioItemViewModel.Checked = selectedValue.HasValue && enumOption.Equals(selectedValue.Value);
                
                radioItemViewModel.Label ??= new LabelViewModel
                {
                    HtmlOrText = new HtmlOrText(GovUkRadioCheckboxLabelTextAttribute.GetLabelText(enumOption)),
                };
                
                viewModel.RadioItems.Add(radioItemViewModel);
            }
        }

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
