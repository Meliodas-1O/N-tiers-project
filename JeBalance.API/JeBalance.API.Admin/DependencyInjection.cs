
namespace JeBalance.API.Admin
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddVIPApplication(this IServiceCollection services)
        {
            services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
            return services;

        }
    }
}
