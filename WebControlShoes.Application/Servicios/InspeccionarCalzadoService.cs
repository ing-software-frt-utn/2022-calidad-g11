using Microsoft.Extensions.Configuration;
using WebControlShoes.Application.Contratos;
using WebControlShoes.Domain.Entities;
using WebControlShoes.Domain.Repository;
using Zapatillas.Domain.Entities;

namespace WebControlShoes.Application.Servicios
{
    public class InspeccionarCalzadoService : IInspeccionarService
    {

        //private readonly IConfiguration _configuration;
        // public readonly IRepository<Modelo> _modelRepository;
        // public readonly IRepository<Colour> _colorRepository;
        public readonly IRepository<LineaProduccion> _LineaProduccion;
        public readonly IRepository<Defecto> _defectosProduccion;
        private readonly IRepository<OrdenProduccion> _OrdenProduccionRepository;
        private readonly IRepository<JornadaLaboral> _JornadaLaboralRepository;
        public readonly IRepository<Usuario> _SupervisorRepository;
        private const int TopeDeDefectos = 5;
        public InspeccionarCalzadoService(   IRepository<OrdenProduccion> ordenProduccionRepository, IRepository<LineaProduccion> linea, IRepository<JornadaLaboral> jornadaLaboralRepository, IRepository<Usuario> supervisorRepository, IRepository<Defecto> defectos)
        {
            //_configuration = configuration;
            _OrdenProduccionRepository = ordenProduccionRepository;
            _LineaProduccion = linea;
            _JornadaLaboralRepository = jornadaLaboralRepository;
            _SupervisorRepository = supervisorRepository;
            _defectosProduccion = defectos;
        }


        public async Task<OrdenProduccion> IniciarInspeccionAsync(string ?supervisorCalidad, string? codigoOP)
        {
 
            Usuario supervisorActual =await _SupervisorRepository.BuscarByAsync(s=> s.NameUsuario== supervisorCalidad);
            OrdenProduccion op = await _OrdenProduccionRepository.BuscarByAsync(op => op.CodigoOP == codigoOP);
           
            op.CrearJornadaLaboral();
            

            // LOGICA REANUDAR OP PAUSADA
            //IMPLEMENTAR
            await _OrdenProduccionRepository.ModificarAsync(op);

            return op;


        }
      
        public async Task RegistrarDefecto(string codigoOP, Guid defectoId, Pie pie, TipoDefecto tipo,  
                                            int hora, int quantity=1)
        {
            Defecto defecto = await _defectosProduccion.BuscarByAsync(d => d.Id == defectoId);

            OrdenProduccion op  =  await _OrdenProduccionRepository.BuscarByAsync(op => op.CodigoOP == codigoOP &&
                                                                                  op.IsActive());

            defecto.Cantidad = quantity;
            defecto.TipoDefecto = tipo;
            
            //--  MOVER AL DOMINIO
            JornadaLaboral ? jornadaActiva = op.GetLastJornadaLaboral();
            
            Alerta ? alerta = op.ObtenerUltimaAlerta();
            DateTime ? horaReinicio=null;

            if (alerta is not null) 
            {
                horaReinicio = alerta.ObtenerHoraRencio();
            }

            jornadaActiva?.RegistrarIncidencia(pie, defecto);
            
            await _OrdenProduccionRepository.ModificarAsync(op);
            //--



            /*
            //OBTENER CANTIDAD PARA CEMAFOROS
            if (horaReinicio is null)
            {
                quantity=jornadaActiva.ObtenerCantidadDeDefectos(pie, tipo);
            }
            else 
            {
                quantity= jornadaActiva.ObtenerCantidadDeDefectos(pie, tipo, horaReinicio);
            }

            return quantity;
           */

          
        }
            





























        private async void ObtenerDatosEnLinea(OrdenProduccion op)
        {
            JornadaLaboral jornadaActiva = op.GetLastJornadaLaboral();

            //var topeObservado = ObtenerTopeDefectos(jornadaActiva, TipoDefecto.Observado);
            //var topeReproceso = ObtenerTopeDefectos(jornadaActiva, TipoDefecto.Reproceso);

            //Crear el semaforo?
            //return new SemaforoDTO()
            //{
            //    Linea = op.Linea.Nrolinea,
            //    ColorSemaforoObservado = op.SemaforoObr
            //}
        }

        //private List<string> ObtenerTopeDefectos(JornadaLaboral jornadaLaboral, TipoDefecto tipo)
        //{
        //    return jornadaLaboral.RegistrosDefecto
        //        .Where(rd =>
        //            rd.Defectos == tipo &&
        //            rd.Hora > DateTime.Now.AddHours(-1))
        //        .GroupBy(rd => rd.Defecto.Descripcion);
        //}
        //    ////REPOSITORIO
            //var defecto =await _defectosProduccion.BuscarPorIdAsync(defecto_id);
            //var props = new List<string>();
            //props.Add("JornadasLaborales");

        //var op = await _OrdenProduccionRepository.BuscarWithChildsAsync(props, (op => op.CodigoOP == CodigoOP));
        //                                    // .Single();

        //var jornada = op.JornadasLaborales.Last();



        ////VERIFICACION
        //if (op is null)  throw new Exception("No se encontro recurso nesesario");

        //if (!op.IsActive()) throw new Exception("No se puede inspeccionar op inactiva");

        ////ADD REGISTRO
        //if (jornada is not null) 
        //{
        //    jornada.CrearRegistro(hora, cantidad, pie, tipo, defecto);
        //}
        //else 
        //{
        //    op.CrearJornadasLaboral();
        //    jornada = op.JornadasLaborales.Last();
        //    jornada.CrearRegistro(hora, cantidad, pie, tipo, defecto);
        //}
        //_OrdenProduccionRepository.Update(op);




        public async void RegistrarParPrimera(string codigoOP, int cantidad, int hora) 
        {
            OrdenProduccion op = await _OrdenProduccionRepository.BuscarPorIdAsync(codigoOP);
            JornadaLaboral jornadaActiva = op.GetLastJornadaLaboral();

            if(op != null)//&& jornadaActiva?.SupervisorCalidad.DNI == SupervisorCalidad.DNI
            {
                op.RegistrarParDePrimera(cantidad, hora, DateTime.Now);
                _OrdenProduccionRepository.ModificarAsync(op); //Hay que hacer Update de OP
            }
            //OrdenProduccion op = await _OrdenProduccionRepository.BuscarPorId(CodigoOP);
        }


        /*
       public void AsociarSupervisor(string supervisorCalidad, string codigoOP)
       {

           var props = new List<string>();
           props.Add("Supervisores");

           var supervisorActual = _SupervisorRepository.BuscarPorId(supervisorCalidad);

           var op = _OrdenProduccionRepository.BuscarWithChilds(props, (op => op.CodigoOP == codigoOP))
                                              .Single();


           if (op.Supervisores.Where(s => s.Rol == Rol.SupervisorCalidad).Any())
           {
               throw new Exception("Ya existe un supervisor de Calidad Asociado");
           }



       }
       */


    }

}

