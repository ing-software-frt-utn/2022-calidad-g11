using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zapatillas.Domain.Entities;

namespace WebControlShoes.Infastructure.Configurations
{
    internal class AlertaConfiguration : IEntityTypeConfiguration<Alerta>
    {
        public void Configure(EntityTypeBuilder<Alerta> builder)
        {

            builder.ToTable("Alertas");

            builder.HasKey(c => c.Id);

            builder.HasAlternateKey(c => c.Reinicio);

            builder.Property(c => c.LimiteAviso)
                    .IsRequired()
                   .HasMaxLength(255);
            
            builder.Property(c => c.Tipo)
                    .IsRequired()
                   .HasMaxLength(255);

    }
    }
}
