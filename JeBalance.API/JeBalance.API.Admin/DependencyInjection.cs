
namespace JeBalance.API.Admin
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assemblies = new[]
            {
                typeof(Domain.Queries.PersonneQueries.FindOnePersonneQueryHandler).Assembly,
                typeof(DependencyInjection).Assembly
            };
            services.AddMediatR(cf => cf.RegisterServicesFromAssemblies(assemblies));


            return services;

        }
    }
}
