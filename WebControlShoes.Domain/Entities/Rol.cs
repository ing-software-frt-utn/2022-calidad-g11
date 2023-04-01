namespace Zapatillas.Domain.Entities
{
    // public class SupervisorCalidad : Usuario, IAggregateRoot
    public enum Rol
    {
        SupervisorLinea,
        SupervisorCalidad
    }
}
        /*
        public int IdSupervisor { get; set; }
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        //public string Mail { get; set; }

        public EstadoSup Estado { get; set; }
       
        public SupervisorCalidad()
        {
            
        }

        public SupervisorCalidad(int idSupervisor, int dni, string nombre, string apellido, EstadoSup estado) : base(password)
        {
            IdSupervisor = idSupervisor;
            Dni = dni;
            Nombre = nombre;
            Apellido = apellido;
            Estado = estado;
        }
    }
}*/
