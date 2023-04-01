using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebControlShoes.Domain.Entities;

namespace WebControlShoes.Infastructure.Configurations
{
    internal class LineaProduccionConfiguration : IEntityTypeConfiguration<LineaProduccion>
    {
        public void Configure(EntityTypeBuilder<LineaProduccion> builder)
        {
            builder.ToTable("LineasProduccion");

            builder.HasKey(l => l.Id);


            builder.HasAlternateKey(c => c.Nrolinea);

            builder.Property(c => c.Description)
                   .IsRequired()
                  .HasMaxLength(255);
        }

       
          
    }
}
