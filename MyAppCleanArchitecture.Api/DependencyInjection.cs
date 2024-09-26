
using MyAppCleanArchitecture.Application;
using MyAppCleanArchitecture.Infrastructure;
using MyAppCleanArchitecture.Core;
namespace MyAppCleanArchitecture.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiDI(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddApplicationDI().
                AddInfrastructureDI()
                .AddCoreDI(configuration);
            return services;
        }
    }
}
