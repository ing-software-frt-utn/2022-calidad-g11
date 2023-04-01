using WebControlShoes.Domain;

namespace Zapatillas.Domain.Entities
{
    public class Colour : EntidadBase<Guid>, IAggregateRoot
    {
        private string _CodigoColor;
        private string _Descripcion;
        

        public Colour(string descripcion, string codigoColor) 
            => (_Descripcion, _CodigoColor) = (descripcion, codigoColor);

        public Colour()
        {
            
        }


        public string CodigoColor
        {
            get { return _CodigoColor; }
            set { _CodigoColor = value; }
        }
        public string Descripcion
        {
            get
            {  
                return _Descripcion;
            }
            set
            {
                if (value != null || value=="")
                {
                    _Descripcion = value;
                }
                else throw new ArgumentNullException("value no puede ser null");
            }
        }

       


        public void ValidationRules() { 

           // dasdasda
        }
    }
}