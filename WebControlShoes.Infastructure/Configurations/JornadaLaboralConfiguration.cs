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
    internal class JornadaLaboralConfiguration : IEntityTypeConfiguration<JornadaLaboral>
    {
        public void Configure(EntityTypeBuilder<JornadaLaboral> builder)
        {
            builder.ToTable("JornadasLaborales");

            builder.HasKey(j => j.Id);

            builder.Property(j => j.FechaInicio)
                   .IsRequired()
                  .HasMaxLength(255);

            builder.Property(j => j.FechaFin)
                   .IsRequired()
                  .HasMaxLength(255);


            var turno = builder.Metadata.FindNavigation(nameof(JornadaLaboral.Turno) + "s");
            turno?.SetPropertyAccessMode(PropertyAccessMode.Field);

            var prim = builder.Metadata.FindNavigation(nameof(JornadaLaboral.ParesPrimera) + "s");
            prim?.SetPropertyAccessMode(PropertyAccessMode.Field);

            var incidencias = builder.Metadata.FindNavigation(nameof(JornadaLaboral.Incidencias));
            incidencias?.SetPropertyAccessMode(PropertyAccessMode.Field);

           
           
            /*

            builder.HasOne(c => c.Turno)
                   .WithMany()
                   .HasForeignKey(c => c.Id);


            builder.HasMany(c => c.ParesPrimera)
                   .WithOne()
                   .HasForeignKey(c => c.Id); 
            

            builder.HasMany(c => c.RegistrosDefecto)
                   .WithOne()
                   .HasForeignKey(c => c.Id);
            */

            
    }
    }
}
