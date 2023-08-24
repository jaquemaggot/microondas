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
    public class PainelMicroondasMap : IEntityTypeConfiguration<PainelMicroondas>
    {
        public void Configure(EntityTypeBuilder<PainelMicroondas> builder)
        {
            builder.ToTable("PainelMicroondas");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Tempo)
                   .IsRequired();
            builder.Property(c => c.Potencia)
                .IsRequired();
            builder.Property(c => c.Cancelado)
                .IsRequired();
            builder.Property(c=> c.DataInicial) 
                .IsRequired();
            builder.Property(c => c.DataFinal)
                .IsRequired();
            builder.Property(c => c.StringDeAquecimento);

        }
    }
}
