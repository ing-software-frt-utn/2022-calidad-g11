using WebControlShoes.Domain;

namespace Zapatillas.Domain.Entities

{
    public class Primera : EntidadBase<Guid>, IAggregateRoot
    {
       // public int IdPrimera { get; set; }
        int _hora;
        public Primera() => Hora=DateTime.Now.Hour;

        
        public int Hora
        {
            get{return _hora;}
            private set{ _hora=value;}
        }
    }
}