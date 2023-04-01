using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zapatillas.Domain.Entities;

namespace WebControlShoes.Infastructure.Configurations
{
    internal class PrimeraConfiguration : IEntityTypeConfiguration<Primera>
    {

        

        public void Configure(EntityTypeBuilder<Primera> builder)
        {
            builder.ToTable("Primeras");

            builder.HasKey(x => x.Id);

            builder.Property(d => d.Hora)
                    .IsRequired();
        }
    }
}
