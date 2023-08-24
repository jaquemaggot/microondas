using Infra.SqlServer.Contexto;
using Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.SqlServer
{
    public static class ServiceCollectionExtensao
    {
        public static IServiceCollection AdicionarSqlServer(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<MicroondasContexto, SqlServerMicroondasContexto>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("WebApi")));

            return services;
        }
    }
}
