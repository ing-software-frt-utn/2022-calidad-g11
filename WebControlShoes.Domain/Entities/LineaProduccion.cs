using Zapatillas.Domain.Entities;

namespace WebControlShoes.Domain.Entities


{
    public class LineaProduccion : EntidadBase<Guid>, IAggregateRoot
    {

        private int _NroLinea;
        private String _Descripcion;

        public LineaProduccion(int nroLinea, string description)
        {
            _NroLinea = nroLinea;
            _Descripcion = description;
        }
        public LineaProduccion()
        {

        }

        public int Nrolinea { get { return _NroLinea; } set { _NroLinea = value; } }
        public string Description { get { return _Descripcion; } set { _Descripcion = value; } }
       

    }
}