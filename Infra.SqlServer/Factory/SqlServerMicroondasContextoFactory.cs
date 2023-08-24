using Infra.SqlServer.Contexto;
using Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.SqlServer.Factory
{
    public class SqlServerMicroondasContextoFactory : IDesignTimeDbContextFactory<MicroondasContexto>
    {
        public MicroondasContexto CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MicroondasContexto>();

            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);

            return new SqlServerMicroondasContexto(builder.Options);
        }

    }
}
