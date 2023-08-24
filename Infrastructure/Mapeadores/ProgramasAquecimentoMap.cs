using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Mapeadores
{
    public class ProgramasAquecimentoMap : IEntityTypeConfiguration<ProgramasAquecimento>
    {
        public void Configure(EntityTypeBuilder<ProgramasAquecimento> builder)
        {
            builder.ToTable("ProgramasAquecimento");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Tempo)
                .IsRequired();
            builder.Property(c => c.Potencia)
                .IsRequired();
            builder.Property(c => c.NomeDoPrograma)
                .IsRequired();
            builder.Property(c => c.Alimento)
                .IsRequired();
            builder.Property(c => c.Aquecimento);
            builder.Property(c => c.StringDeAquecimento)
                .IsRequired();
            builder.Property(c => c.InstrucoesComplementares);
            builder.Property(c => c.Padrao);    
        }
    }
}
