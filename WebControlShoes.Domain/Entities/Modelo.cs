using WebControlShoes.Domain;

namespace Zapatillas.Domain.Entities
{
    public class Modelo : EntidadBase<Guid>, IAggregateRoot
    {

        string _Sku;
        string _Denominacion;
        public Modelo(string sku, string description, int limiteObservadoSuperior, int limiteObservadoInferior, int limiteReprocesoSuperior, int limiteReprocesoInferior) 
        {
            _Sku=sku;
            _Denominacion=description;
            LimiteSuperiorObservado=limiteObservadoSuperior;
            LimiteInferiorObservado = limiteObservadoInferior;
            LimiteSuperiorReproceso= limiteReprocesoSuperior;
            LimiteInferiorReproceso=limiteReprocesoInferior;

        }

        public Modelo() { 
        
        }

        public void ValidationRules()
        {
           // Guard.Against.Null(basket, nameof(basket));  // USE ARDALIS

        }

        public (String , bool) NecesitoAlerta(TipoDefecto tipo, int cantidad) 
        {
            if (LimiteInferiorObservado < cantidad && TipoDefecto.Observado == tipo)
                return (nameof( LimiteInferiorObservado), true);
            
            if (LimiteSuperiorObservado < cantidad && TipoDefecto.Observado == tipo)
                return (nameof( LimiteSuperiorObservado), true);
            
            if (LimiteInferiorReproceso < cantidad && TipoDefecto.Reproceso == tipo)
                return (nameof( LimiteInferiorReproceso), true);

            if (LimiteSuperiorReproceso < cantidad && TipoDefecto.Reproceso == tipo)
                return (nameof( LimiteSuperiorReproceso), true);

            return (null, false);
        }

        #region PROPIEDADES
        public string Sku{ get{return _Sku;} set{_Sku=value;} }
        public string Denominacion{get{return _Denominacion;} set{_Denominacion=value;}}
        public int LimiteInferiorObservado{get;set;}
        public int LimiteInferiorReproceso{get;set;}
        public int LimiteSuperiorObservado{get;set;}
        public int LimiteSuperiorReproceso{get;set;}
        #endregion




    }
}