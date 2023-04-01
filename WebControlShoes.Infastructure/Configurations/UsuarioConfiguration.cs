using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebControlShoes.Domain.Entities;
using Zapatillas.Domain.Entities;

namespace WebControlShoes.Infastructure.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {

        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(c => c.Id);

            builder.HasAlternateKey(c => c.NameUsuario);

            builder.Property(c => c.Password)
                    .IsRequired()
                   .HasMaxLength(50);
            
            builder.Property(c => c.Rol)
                    .IsRequired()
                   .HasMaxLength(50);
         
        }
    }
}
