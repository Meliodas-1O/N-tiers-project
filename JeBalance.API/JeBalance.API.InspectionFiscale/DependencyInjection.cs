
namespace JeBalance.API.InspectionFiscale
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInspectFiscaleApplication(this IServiceCollection services)
		{
			services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
			return services;

		}
	}
}
