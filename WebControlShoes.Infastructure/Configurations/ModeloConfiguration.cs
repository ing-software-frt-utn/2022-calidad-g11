using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zapatillas.Domain.Entities;

namespace WebControlShoes.Infastructure.Configurations
{
    public class ModeloConfiguration : IEntityTypeConfiguration<Modelo>
    {
        public void Configure(EntityTypeBuilder<Modelo> builder)
        {
            // builder.HasKey(nameof(Modelo.IdModelo));
            builder.ToTable("Modelos");
           
            builder.HasKey(m => m.Id);
            //.IsRequired();

            builder.HasAlternateKey(m => m.Sku);
               
            builder.Property(m => m.LimiteSuperiorReproceso)
                .IsRequired()
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(m => m.LimiteInferiorReproceso)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(m => m.LimiteSuperiorObservado)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(m => m.LimiteInferiorObservado)
                .HasMaxLength(100)
                .IsRequired();

            //builder.Navigation(nameof(Modelo));
                
        }
    }
}
