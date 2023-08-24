using Dominio.Entidades;
using Infraestrutura.Mapeadores;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Infraestrutura.Contexto
{
    public class MicroondasContexto : DbContext

    {
        public DbSet<PainelMicroondas> PainelMicroondas { get; set; }

        public DbSet<ProgramasAquecimento> ProgramasAquecimento { get; set; }


        public MicroondasContexto([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PainelMicroondas>(new PainelMicroondasMap().Configure);
            modelBuilder.Entity<ProgramasAquecimento>(new ProgramasAquecimentoMap().Configure);
        }
    }
}
