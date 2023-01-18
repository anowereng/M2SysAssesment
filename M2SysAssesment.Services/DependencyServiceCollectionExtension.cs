

using M2SysAssesment.Services;
using Microsoft.Extensions.DependencyInjection;

namespace M2SysAssesment.Services
{
    public static class DependencyServiceCollectionExtension
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddTransient<IImageService,ImageService>();

            return services;
        }
    }
}
