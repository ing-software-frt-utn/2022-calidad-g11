using WebControlShoes.Domain;

namespace Zapatillas.Domain.Entities

{
    public class Turno : EntidadBase<Guid>, IAggregateRoot
    {
        public int HoraInicio { get; set; }
        public int HoraFin { get; set; }
        public string Descripcion { get; set; }
        internal Turno(int horaInicio,int horaFin,string descripcion) 
        { 
           (HoraInicio,HoraFin)=(horaInicio,horaFin);
            //generar descripcion

        }
        public Turno()
        {
            
        }

       //revisar la logica...

            public bool LaHoraPertenece(int hora) { //revisar la logica...
            if (HoraInicio < HoraFin && HoraInicio < hora && hora < HoraFin)
            {
                return true;
            }
            else
            {
                if (HoraInicio > HoraFin && HoraInicio > hora && hora > HoraFin) {   //  inicia 13  -- termian 10  (no validos 11-12)
                    return true;
                }
            }
            return false;
        }

    }
}