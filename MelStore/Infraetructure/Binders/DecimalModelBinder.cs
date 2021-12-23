using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace MelStore.Infraetructure.Binders
{
  public class DecimalModelBinder : IModelBinder
  {
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
      if (bindingContext == null)
      {
        throw new ArgumentNullException(nameof(bindingContext));
      }

      var modelName = bindingContext.ModelName;

      // Try to fetch the value of the argument by name
      var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

      if (valueProviderResult == ValueProviderResult.None)
      {
        return Task.CompletedTask;
      }

      bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

      var value = valueProviderResult.FirstValue;

      // Check if the argument value is null or empty
      if (string.IsNullOrEmpty(value))
      {
        return Task.CompletedTask;
      }

      object actualValue = null;
      try
      {
        actualValue = Convert.ToDecimal(value, CultureInfo.CurrentCulture);
      }
      catch (FormatException e)
      {
        bindingContext.ModelState.TryAddModelError(modelName, "Valor deve ser um decimal.");
        return Task.CompletedTask;
      }

      bindingContext.Result = ModelBindingResult.Success(actualValue);
      return Task.CompletedTask;      
    }    
  }
}
