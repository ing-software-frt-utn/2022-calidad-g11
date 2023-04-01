using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
//using WebControlShoes.Domain.Entities;
//using Zapaitllas.Domain.Entities;
using Zapatillas.Domain.Entities;

namespace WebControlShoes.Infastructure.Configurations
{
    public class OrdenProduccionConfiguration : IEntityTypeConfiguration<OrdenProduccion>
    {
        //Por las limitaciones que tienen las anotaciones en entity Framework
        //usamos Fluent API para poder cumplir con lo propuesto x Martin Fowler
        public void Configure(EntityTypeBuilder<OrdenProduccion> builder)
        {
            builder.ToTable("OrdenesProduccion");

            builder.HasKey(t => t.Id);

            builder.HasAlternateKey(c => c.CodigoOP);

            builder.Property(c => c.Estado)
                    .IsRequired()
                    .HasMaxLength(10);

            builder.Property(c => c.FechaInicio)
                   //.IsRequired()
                   .HasMaxLength(10);

            builder.Property(c => c.FechaFin)
                  //.IsRequired()
                  .HasMaxLength(10);

            /*
            builder.HasOne(m => m.Modelo)
                    .WithMany()
                    .HasForeignKey(m => m.Sku); ;
            */
            var colourNavigation = builder.Metadata.FindNavigation(nameof(OrdenProduccion.Colour) + "s");
            colourNavigation?.SetPropertyAccessMode(PropertyAccessMode.Field);
            
            var modelo = builder.Metadata.FindNavigation(nameof(OrdenProduccion.Modelo) + "s");
            modelo?.SetPropertyAccessMode(PropertyAccessMode.Field);
            
            
            var jornada = builder.Metadata?.FindNavigation(nameof(OrdenProduccion.JornadasLaborales)+"s");
            jornada?.SetPropertyAccessMode(PropertyAccessMode.Field);
            

            var linea = builder.Metadata.FindNavigation(nameof(OrdenProduccion.Linea)+"s");
            linea?.SetPropertyAccessMode(PropertyAccessMode.Field);


           var usuarios = builder.Metadata.FindNavigation(nameof(OrdenProduccion.Supervisores));
            usuarios?.SetPropertyAccessMode(PropertyAccessMode.Field);

            var alertas = builder.Metadata.FindNavigation(nameof(OrdenProduccion.Alertas));
            alertas?.SetPropertyAccessMode(PropertyAccessMode.Field);
            /*
            builder.HasOne(c => c.Linea)
                    .WithMany()
                    .HasForeignKey(l => l.NroLinea);
            */

            /*
            builder.HasOne(c => c.Colour)
                    .WithMany()
                    .HasForeignKey(c => c.CodigoColor);
            
            builder.HasOne(c => c.Linea)
                    .WithMany()
                    .HasForeignKey(c => c.NroLinea);
            */
            /*
            builder.HasMany(c => c._JornadasLaborales)
                   .WithOne()
                   .HasForeignKey(c => c.Id_Jornada);
            */


            /*

            */




            /*
                        builder.Property(b => b.BuyerId)
                            .IsRequired()
                            .HasMaxLength(256);
            */
            /*
             * 
            builder.HasOne(m => m.Linea)
                   .WithMany()
                   .HasForeignKey(m => m.N);
            */
            /*
            builder.HasOne(s => s.SupervisorLinea)
                    .WithMany()
                    .HasForeignKey(s => s.IdSupervisor); 
            */

            //throw new NotImplementedException();
        }






        /* EJEMPLO DE CONFIGURACION
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(Order.OrderItems));

            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.OwnsOne(o => o.ShipToAddress, a =>
            {
                a.WithOwner();

                a.Property(a => a.ZipCode)
                    .HasMaxLength(18)
                    .IsRequired();

                a.Property(a => a.Street)
                    .HasMaxLength(180)
                    .IsRequired();

                a.Property(a => a.State)
                    .HasMaxLength(60);

                a.Property(a => a.Country)
                    .HasMaxLength(90)
                    .IsRequired();

                a.Property(a => a.City)
                    .HasMaxLength(100)
                    .IsRequired();




        
           
            public int Id_OP { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public SupervisorLinea? SupervisorLinea { get; set; }
        public LineaProduccion Linea { get; set; }
        public Modelo Modelo { get; set; }
        public Color Color { get; set; }
        public Estado Estado { get; set; }





            });
        }*/
    }
}
