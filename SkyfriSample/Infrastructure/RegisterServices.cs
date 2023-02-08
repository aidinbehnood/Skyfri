
using Microsoft.Extensions.DependencyInjection;
using SkyfriSample.Contract.Repository;
using SkyfriSample.Contract.Service;
using SkyfriSample.Data.Repository;
using SkyfriSample.Services;

namespace SkyfriSample.Infrastructure
{
    public static class RegisterServicesExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ITenantRepository, TenantRepository>();
            services.AddScoped<ITenantService, TenantService>();
            services.AddScoped<IPortfolioRepository, PortfoliosRepository>();
            services.AddScoped<IPortfoliosService, PortfoliosService>();
            return services;
        }
    }
}
