using Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.SqlServer.Contexto
{
    public class SqlServerMicroondasContexto : MicroondasContexto
    {
        public SqlServerMicroondasContexto(DbContextOptions options) : base(options)
        {
        }
    }
}
