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
    internal class IncidenciaConfiguration : IEntityTypeConfiguration<Incidencia>
    {
        public void Configure(EntityTypeBuilder<Incidencia> builder)
        {
            builder.ToTable("Incidencia");

            builder.HasKey(x => x.Id);

            builder.Property(d => d.Hora)
                    .IsRequired();

            builder.Property(d => d.Pie)
                    .IsRequired();
            /*
            builder.HasOne(x => x.Defecto)
                   .WithMany()
                   .HasForeignKey(x => x.IdDefecto);
            */

            var defectos = builder.Metadata.FindNavigation(nameof(Incidencia.Defectos));
            defectos?.SetPropertyAccessMode(PropertyAccessMode.Field);


        }
        //private List<string> ObtenerTopeDefectos(JornadaLaboral jornadaLaboral, TipoDefecto tipo)
        //{
        //    return jornadaLaboral.RegistrosDefecto
        //        .Where(rd =>
        //            rd.Defectos.Any == tipo &&
        //            rd.Hora == DateTime.Now.AddHours(-1))
        //        .GroupBy(RegistroDefecto => RegistroDefecto.des)
        //}
    }
}
