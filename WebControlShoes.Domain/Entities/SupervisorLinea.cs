using WebControlShoes.Domain;
 
namespace Zapatillas.Domain.Entities
{
    public class SupervisorLinea : EntidadBase<Guid>, IAggregateRoot
    {
        public int IdSupervisor { get; set; }
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }

        public EstadoSup Estado { get; set; }
        public SupervisorLinea(int dni,string nombre,string apellido,string mail )
        {
            Dni= dni;
            Nombre= nombre;
            Apellido= apellido;
            Mail= mail;
            Estado = EstadoSup.LIBRE;
        }
    }

    
}
