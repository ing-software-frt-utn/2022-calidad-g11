using Microsoft.Win32;
using System.IO.Pipelines;
using WebControlShoes.Domain;

namespace Zapatillas.Domain.Entities

{
    public class JornadaLaboral : EntidadBase<Guid>, IAggregateRoot
    {
        List<Incidencia> _incidencias;
        private DateTime? _fechaFin = null;
        #region props
        //  public int Id_Jornada { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get { return _fechaFin; } set { _fechaFin = value; } }
        public virtual Turno Turno { get; set; }
        public string CodigoOP { get; set; }

        public virtual List<Primera> ParesPrimera { get; set; }
        public virtual List<Incidencia> Incidencias
        { get { return _incidencias; } set { _incidencias = value; } }

        public int TotalPrimera { get; set; }

        public int TotalSegunda { get; set; }

        public int IdTurno { get; set; }
        #endregion

        internal JornadaLaboral(Turno turno)
        {
            // Id_Jornada = id;
            Turno = turno;
            FechaInicio = DateTime.Now;
            ParesPrimera = new List<Primera>();
            Incidencias = new List<Incidencia>();
        }

        public JornadaLaboral(DateTime horaInicio)
        {
            FechaInicio= horaInicio;
            ParesPrimera = new List<Primera>();
            Incidencias = new List<Incidencia>();
        }
        
        public JornadaLaboral()
        {

        }


        public void RegistrarIncidencia(Pie pie, Defecto? defecto)
        {
            Incidencia incidencia = null;

            if (!_incidencias.Where(r => r.Pie == pie && DateTime.Now.Hour == r.Hora).Any())
            {
                incidencia = NuevaIncidencia(pie, defecto);
            }
            else
            {// obtengo incidencia
                incidencia = _incidencias.Where(r => r.Pie == pie && DateTime.Now.Hour == r.Hora)
                                             .Single();
            }

            if (defecto is not null)
                incidencia.AddDefecto(defecto);
            else
                throw new NotImplementedException(); //agregar primera

        }



        public int ObtenerCantidadDeDefectos(Pie pie,
                                             TipoDefecto tipo,
                                             DateTime? hora=null) // hora de reinicio y si no null
        {
            int cantidad=0;

            if (hora is null)
            {
                var incidencias =  _incidencias.Where(r => r.Pie == pie);
                
                foreach (var r in incidencias) // SE PUEDE PASAR A UNA FUNCION
                {
                    cantidad += r.Defectos.Where(d => d.TipoDefecto == tipo)
                                          .Sum(d => d.Cantidad);
                }

            }
            else 
            {
                var incidencias = _incidencias.Where(r => r.Pie == pie && r.Hora >= hora?.Hour);
               
                foreach (var r in incidencias) // iz 3 -> incidencias
                {
                    cantidad += r.Defectos.Where(d => d.TipoDefecto == tipo)
                                          .Sum(d => d.Cantidad);
                }
            }                   
            return cantidad;
       
        }


        public bool IsActive() 
        {
            return _fechaFin is null || DateTime.Now.Hour <= _fechaFin.Value.Hour ;
        }

        //GET HORAS (10 | 12)   ->INSPECCIONAR CALZADO 

        public Incidencia NuevaIncidencia( Pie pie, Defecto? defecto)
        {
            Incidencia registro = new Incidencia( pie);
            if (defecto is not null)
                registro.AddDefecto(defecto);
            else
                throw new NotImplementedException();
                // AGREGAR PAR DE PRIMERA  registro.AddPrimera();
                
            return registro;
           
        }



        public void AddPrimera(Primera primera)
        {
            if(primera is not null)
            {
                ParesPrimera.Add(primera);
            }
        }
       


        
           

        }
}