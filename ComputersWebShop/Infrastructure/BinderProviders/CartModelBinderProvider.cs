using ComputersLibrary;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ComputersWebShop.Infrastructure.ModelBinders;

namespace ComputersWebShop.Infrastructure.BinderProviders
{
    public class CartModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            IHttpContextAccessor contextAccessor = context.Services.GetRequiredService<IHttpContextAccessor>();
            return context.Metadata.ModelType == typeof(Cart) ?
                new CartModelBinder(contextAccessor) : null;
        }
    }
}
