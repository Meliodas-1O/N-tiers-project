
using JeBalance.API.Admin.Services.Models;
using JeBalance.API.InspectionFiscale.Service;
using JeBalance.Domain.Services;

namespace JeBalance.API.InspectionFiscale
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInspectFiscaleApplication(this IServiceCollection services)
		{
            services.AddScoped<IDenonciationReponseService, DenonciationReponseService>();
            services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
			return services;

		}
	}
}
