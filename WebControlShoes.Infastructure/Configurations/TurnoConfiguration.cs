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
    internal class TurnoConfiguration : IEntityTypeConfiguration<Turno>
    {
        public void Configure(EntityTypeBuilder<Turno> builder)
        {
           
            builder.ToTable("Turnos");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.HoraInicio)
                   .IsRequired();
            builder.Property(t => t.HoraFin)
                    .IsRequired();
            builder.Property(t => t.Descripcion)
                   .IsRequired();
            
        }
    }
}
