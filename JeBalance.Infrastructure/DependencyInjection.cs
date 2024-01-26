using JeBalance.Domain.Repository;
using JeBalance.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
                services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

                services.AddScoped<IReponseRepository, ReponseRepositorySQLite>();
                services.AddScoped<IDenonciationRepository, DenonciationRepositorySQLite>();
                services.AddScoped<IPersonneRepository, PersonneRepositorySQLite>();
                return services;

        }
    }
}
