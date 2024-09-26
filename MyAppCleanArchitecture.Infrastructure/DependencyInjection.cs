using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MyAppCleanArchitecture.Core.Interfaces;
using MyAppCleanArchitecture.Core.Options;
using MyAppCleanArchitecture.Infrastructure.Data;
using MyAppCleanArchitecture.Infrastructure.Repository;

namespace MyAppCleanArchitecture.Infrastructure
{
    public static class DependencyInjection
    {
        // public static IServiceCollection AddInfrastructureDI(this IServiceCollection services,IConfiguration configuration)
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            //services.AddDbContext<AppDbContext>(options =>
            //{
            //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            //});
            services.AddDbContext<AppDbContext>((provider, options) =>
            {
                options.UseSqlServer(provider.GetRequiredService<IOptionsSnapshot<ConnectionStringOptions>>().Value.DefaultConnection);
            });
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            return services;
        }
    }
}
