using JeBalance.API.Public.Services;

namespace JeBalance.Public.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
			services.AddScoped<PersonneService>();
			services.AddScoped<DenonciationService>();
			services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
            return services;
        }
    }
}
