using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WebControlShoes.Domain.Entities;
using WebControlShoes.Infastructure.Configurations;
using Zapatillas.Domain.Entities;

namespace WebControlShoes.Infastructure
{
     public interface IAppContext {
        /*
         * Verifica que nosotros podamos conectarnos a la BD 
         */
        Task<bool> CanConnectAsync();
    }


    public class AppDbContext : DbContext , IAppContext
    {
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
           
        }

        public DbSet<Colour> Colors { get; set; }
        public DbSet<Modelo> Modelos { get; set; }

        public DbSet<OrdenProduccion> OrdenesProduccion { get; set; }
        public DbSet<Turno> Turnos { get; set; }
        public DbSet<LineaProduccion> LineasProduccion { get; set; }
        public DbSet<Primera> Primeras { get; set; }
        public DbSet<Defecto> Defectos { get; set; }
        public DbSet<Incidencia> RegistrosDefecto { get; set; }
        public DbSet<JornadaLaboral> JornadasLaborales { get; set; }
       // public DbSet<SupervisorLinea> SupervisoresLineas { get; set; }
        
        public async Task<bool> CanConnectAsync() => await Database.CanConnectAsync();

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {

            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); 

            //modelBuilder.Ignore<Alerta>();
            //modelBuilder.Ignore<SupervisorCalidad>();
            modelBuilder.Ignore<SupervisorLinea>();
           // modelBuilder.Ignore<Primera>();
           // modelBuilder.Ignore<Defecto>();
           // modelBuilder.Ignore<Alerta>();

            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new AlertaConfiguration());
            modelBuilder.ApplyConfiguration(new LineaProduccionConfiguration());
            //modelBuilder.ApplyConfiguration(new AlertaConfiguration());
            modelBuilder.ApplyConfiguration(new ColourConfiguration());
            modelBuilder.ApplyConfiguration(new ModeloConfiguration());

            modelBuilder.ApplyConfiguration(new TurnoConfiguration());
            modelBuilder.ApplyConfiguration(new PrimeraConfiguration());
            modelBuilder.ApplyConfiguration(new DefectoConfiguration());
            modelBuilder.ApplyConfiguration(new IncidenciaConfiguration());
            modelBuilder.ApplyConfiguration(new JornadaLaboralConfiguration());
           
            modelBuilder.ApplyConfiguration(new OrdenProduccionConfiguration());
            // modelBuilder.ApplyConfiguration(new SupervisorLineaConfiguration());

            //FLUENT API entity Framework
            //Link: https://learn.microsoft.com/en-us/ef/ef6/modeling/code-first/fluent/types-and-properties
        }


    }
}
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            //modelBuilder.HasDefaultSchema("EfCore");
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<SupervisorLinea>().HasOne(s => s.Id);
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); 
