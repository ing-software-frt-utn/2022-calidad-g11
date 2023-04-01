using WebControlShoes.Domain;
using WebControlShoes.Domain.Entities;

//using Ardalis.GuardClauses;

namespace Zapatillas.Domain.Entities
{
    public class OrdenProduccion : EntidadBase<Guid>, IAggregateRoot
    {
        private List<Usuario> _supervisores = new List<Usuario>();
        private List<JornadaLaboral> _jornadasLaborales = new List<JornadaLaboral>();


        private Estado _estado;
        private List<Alerta> _alertas= new List<Alerta>();
        public string CodigoOP { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public virtual List<Usuario> Supervisores { get { return _supervisores; }  set { _supervisores = value; } }
        public virtual LineaProduccion Linea { get; set; }
        public virtual List<JornadaLaboral>? JornadasLaborales { get { return _jornadasLaborales; } private set { _jornadasLaborales = value; } }
        public virtual Modelo Modelo { get; set; }
        public virtual Colour Colour { get; set; }
        public Estado Estado { get { return _estado; }  set { _estado = value; } }
        public virtual List<Alerta>? Alertas { get { return _alertas; } set { _alertas = value; } }


        // public string Sku { get; set; }
        // public string CodigoColor { get; set; }
        //public int NroLinea { get; set; }
        // public string Tipo { get; set; }

        //        public int Id_Jornada { get; set; }
        //CAMINO ENCAPSULADO
        public OrdenProduccion(string codigoOp, Modelo modelo, LineaProduccion linea, Colour color)
        {
            CodigoOP = codigoOp;
            Modelo = modelo;
            Linea = linea;
            Colour = color;
            //JornadasLaborales = new List<JornadaLaboral>();
            //CrearJornadasLaboral();
            //InicializarSemaforo();
            FechaInicio = DateTime.Now;
            MarcarIniciada();
        }

        public OrdenProduccion(string codgigoOP, Modelo modelo, LineaProduccion linea, Colour color, Usuario supervisorLinea)
        {
            CodigoOP = codgigoOP;
            Modelo = modelo;
            Linea = linea;
            Colour = color;
            // _supervisores = new List<Usuario>();
            _supervisores.Add(supervisorLinea);
            //JornadasLaborales = new List<JornadaLaboral>();
            //CrearJornadasLaboral();
            //InicializarSemaforo();
            FechaInicio = DateTime.Now;
            MarcarIniciada();
        }

        // CAMINO SIN ENCAPSULAR

        public OrdenProduccion(string id, Modelo modelo, LineaProduccion linea, Colour color, JornadaLaboral jornadaLaboral)
        {
            CodigoOP = id;
            Modelo = modelo;
            Linea = linea;
            Colour = color;
            AgregarJornadasLaboral(jornadaLaboral);
            MarcarIniciada();
        }


        public OrdenProduccion()
        {

        }


        public void CrearJornadasLaboral()
        {
            JornadasLaborales.Add(new JornadaLaboral(DateTime.Now));
        }



        public void AgregarJornadasLaboral(JornadaLaboral jornadaLaboral)
        {
            _jornadasLaborales.Add(jornadaLaboral);
        }

        public JornadaLaboral? GetLastJornadaLaboral()
        {
           return _jornadasLaborales.Where( j => j.IsActive()).Any() ? _jornadasLaborales.Where(j => j.IsActive()).Last() : null ;
        }

        public bool IsActive()
        {
            return  (Estado==Estado.Iniciada);
        }

        public bool IsQualitySupervisorAssociated()
        {
            return _supervisores.Where(s => s.Rol == Rol.SupervisorCalidad).Any();
        }

        public Alerta? ObtenerUltimaAlerta()
        {
           return _alertas.Any() ? _alertas.Last() : null;
        }

        public void IniciarOrden() 
        {

            MarcarIniciada();
            //COMPLETAR - CONTROLES
            /*
            if (Estado != Estado.Finalizada && Estado != Estado.Iniciada && SupervisorLinea is not null) {
                FechaInicio = DateTime.Now;
                MarcarIniciada();
                if (!_JornadasLaborales.Any())
                {
                    
                   // Turno turno=new Turno(FechaInicio, FechaFin);
                   // _JornadasLaborales.Add( new JornadaLaboral());
                }
            }
            */
        }
        public OrdenProduccion MarcarIniciada()
        {
           /* if (Estado != Estado.Pausada)
                throw new InvalidOperationException("No se puede iniciar una orden que no este pausada");
           */
            Estado = Estado.Iniciada;
            return this;
        }
        public OrdenProduccion MarcarPausada() 
        {
            if (Estado != Estado.Iniciada)
                throw new InvalidOperationException("No se puede pausar una orden que no este iniciada");

            Estado = Estado.Pausada;
            return this;
        }
        public OrdenProduccion MarcarFinalizada()
        {
            Estado = Estado.Finalizada;
            return this;
        }

        public void AsociarSupervisorCalidad(Usuario supervisor)
        {

            if (!_supervisores.Where(s => s.Rol == Rol.SupervisorCalidad).Any())
            {
                _supervisores.Add(supervisor);
            }
            else
            {
                throw new InvalidOperationException("error al asociar supervisor de Calidad");
            }
        }

        public void AsociarSupervisorLinea(Usuario supervisor) {

            if (  !_supervisores.Where(s => s.Rol==Rol.SupervisorLinea ).Any()  ) 
            {
                _supervisores.Add(supervisor);           
            }
            else 
            {
              throw new InvalidOperationException("error al asociar supervisor de linea");
            }      
        }
        public void CrearJornadaLaboral() 
        {

           // if (_estado==Estado.Iniciada && !_supervisores.Where(s => s.Rol==Rol.SupervisorCalidad ).Any()  ) 
            if (!_supervisores.Where(s => s.Rol==Rol.SupervisorCalidad ).Any() && _estado == Estado.Iniciada) 
            {
                //_supervisores.Add(supervisor);
                CrearJornadasLaboral();
            }
             else 
            {
              throw new InvalidOperationException("error al asociar supervisor de calidad");
            }
           
          ///  return this;
        }
        /*
        public void DesasociarSupervisorLinea(Usuario supervisor)
        {
            if (SupervisorLinea.Dni == dni) {
                SupervisorLinea.Estado = EstadoSup.LIBRE;
                SupervisorLinea = null;
            }
        }
        */
        

        public void AgregarJornadaLaboral(int dni)
        {
           
        }


         public void RegistrarParDePrimera(int cantidad, int horaPlanilla, DateTime horaActual)
            {
                if(Estado == Estado.Iniciada)
                {
                    RegistrarParDePrimera(cantidad, horaPlanilla, horaActual); //Falta verificar si Jornada es activa
                }
                else
                {
                    throw new Exception("La Orden de Produccion no esta activa");
                }
            }


      /*  public void RegistrarDefecto(int cantidad, Pie pie, Guid idDefecto, int horaPlanilla, DateTime horaActual)
        {
            if (Estado == Estado.Iniciada)
            {
                //AsociarSemoforo() , Un metodo que lo asocie con el semaforo

              //  RegistrarDefecto(cantidad, pie, idDefecto, horaPlanilla, horaActual);
                //ActualizarSemaforo(cantidad, defecto)
            }
            else
            {
                throw new Exception("La Orden de Produccion no esta activa");
            }
        }
      */

    }

    
}