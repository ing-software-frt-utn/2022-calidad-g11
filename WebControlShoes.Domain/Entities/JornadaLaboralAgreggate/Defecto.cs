using WebControlShoes.Domain;

namespace Zapatillas.Domain.Entities
{
    public class Defecto : EntidadBase<Guid>, IAggregateRoot
    {
      //  public int IdDefecto { get; set; }
        //public Pie Pie { get; set; }
        public string Descripcion { get; set; }
        public TipoDefecto TipoDefecto { get; set; }
        public int Cantidad { get; set; }
        public Defecto(string descripcion, TipoDefecto tipo)
        {
            (Descripcion, TipoDefecto) =(descripcion, tipo);
        }

        public Defecto()
        {
            
        }



    }
}