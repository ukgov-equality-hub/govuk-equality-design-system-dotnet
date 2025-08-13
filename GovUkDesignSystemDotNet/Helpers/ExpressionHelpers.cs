using System.Linq.Expressions;

namespace GovUkDesignSystemDotNet.Helpers;

internal static class ExpressionHelpers
{
    public static TProperty GetPropertyValueFromModelAndExpression<TModel, TProperty>(
        TModel model,
        Expression<Func<TModel, TProperty>> propertyLambdaExpression)
        where TModel : class
    {
        Func<TModel, TProperty> compiledExpression = propertyLambdaExpression.Compile();
        TProperty currentPropertyValue = compiledExpression(model);
        return currentPropertyValue;
    }
}