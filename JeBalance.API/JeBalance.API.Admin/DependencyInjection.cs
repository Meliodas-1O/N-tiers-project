
using JeBalance.API.Admin.Services;
using JeBalance.API.Admin.Services.Models;

namespace JeBalance.API.Admin
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddVIPApplication(this IServiceCollection services)
        {
			services.AddScoped<IVIPService, VIPService>();

			services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
            return services;

        }
    }
}
