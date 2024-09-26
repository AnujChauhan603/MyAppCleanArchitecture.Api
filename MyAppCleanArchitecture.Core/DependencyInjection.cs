using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyAppCleanArchitecture.Core.Options;

namespace MyAppCleanArchitecture.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCoreDI(this IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<ConnectionStringOptions>(configuration.GetSection(ConnectionStringOptions.SectionName));  
            return services;
        }
    }

    
}
