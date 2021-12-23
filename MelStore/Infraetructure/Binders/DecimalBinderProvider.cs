using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace MelStore.Infraetructure.Binders
{
  public class DecimalBinderProvider : IModelBinderProvider
  {
    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
      if (context == null)
      {
        throw new ArgumentNullException(nameof(context));
      }

      if (context.Metadata.ModelType == typeof(decimal))
      {
        return new BinderTypeModelBinder(typeof(DecimalModelBinder));
      }

      return null;
    }
  }
}
