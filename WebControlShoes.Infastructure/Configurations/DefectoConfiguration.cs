using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zapatillas.Domain.Entities;

namespace WebControlShoes.Infastructure.Configurations
{
    internal class DefectoConfiguration : IEntityTypeConfiguration<Defecto>
    {
        public void Configure(EntityTypeBuilder<Defecto> builder)
        {
            builder.ToTable("Defectos");

            builder.HasKey(x => x.Id);

            builder.Property(d => d.TipoDefecto)
                    .IsRequired();
            
            builder.Property(d => d.Descripcion)
                   .IsRequired();


        }
    }
}
