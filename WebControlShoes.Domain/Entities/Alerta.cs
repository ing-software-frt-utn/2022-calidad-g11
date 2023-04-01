using System.Net.Http.Headers;
using WebControlShoes.Domain;

namespace Zapatillas.Domain.Entities
{
    public class Alerta  : EntidadBase<Guid>, IAggregateRoot 
    {

        private DateTime? _reinicio;
        public DateTime? Reinicio { get { return _reinicio;  } set { _reinicio = value; } }
        public DateTime LimiteAviso { get; set; }
        public TipoDefecto Tipo { get; set; }

        public Alerta()
        {
            
        }

        public DateTime? ObtenerHoraRencio() 
        {
            return _reinicio;
        }

    }
}
