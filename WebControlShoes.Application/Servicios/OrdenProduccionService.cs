

using Microsoft.Extensions.Configuration;
using WebControlShoes.Application.Contratos;
using WebControlShoes.Domain.Entities;
using WebControlShoes.Domain.Repository;
using Zapatillas.Domain.Entities;

namespace WebControlShoes.Application.Servicios
{
    public class OrdenProduccionService : IOrdenProduccionService
    {
        private readonly IConfiguration _configuration;
        public readonly IRepository<Modelo> _modelRepository;
        public readonly IRepository<LineaProduccion> _LineaProduccionRepository;
        public readonly IRepository<Colour> _colorRepository;
        public readonly IRepository<Usuario> _SupervisorRepository;
        public readonly IRepository<OrdenProduccion> _OrdenProduccionRepository;
        public readonly IRepository<JornadaLaboral> _JornadaLaboralRepository;

        public OrdenProduccionService(IConfiguration configuration, IRepository<OrdenProduccion> ordenProduccionRepository, IRepository<LineaProduccion> lineaRepository, IRepository<Modelo> modeloRepository, IRepository<Colour> colorRepository, IRepository<JornadaLaboral> jornadaLaboralRepository, IRepository<Usuario> supervisorRepository)
        {
            _configuration = configuration;
            _OrdenProduccionRepository = ordenProduccionRepository;
            _LineaProduccionRepository = lineaRepository;
            _modelRepository = modeloRepository;
            _colorRepository = colorRepository;
            _JornadaLaboralRepository = jornadaLaboralRepository;
            _SupervisorRepository = supervisorRepository;
        }

        /*
        public  OrdenProduccion CrearOrdenProduccion(string codigoColor, int nroLinea, string sku, string codigoOP, string codigoSupervisor)
        {
           
        }
        */
        public async Task<IEnumerable<OrdenProduccion>> GetAll()
        {
            var props = new List<string>() { "Supervisores", "Linea", "Colour", "Modelo", "JornadasLaborales" };
            // props.Add("Estado");
            // var op = await _OrdenProduccionRepository.BuscarWithChildsAsync(props , (x => x.CodigoOP is not null) );
            var op = await _OrdenProduccionRepository.FindAll();
            if (op == null)
            {
                throw new NullReferenceException();
            }
            // throw new NotImplementedException();

            return op;
        }


        public async Task<OrdenProduccion> CrearOrdenProduccionAsync(string codigoColor, int nroLinea, string sku, string codigoOP, string codigoSupervisor)
        {
            var modelo = await _modelRepository.BuscarByAsync(m => m.Sku == sku);
            var color = await _colorRepository.BuscarByAsync(c => c.CodigoColor == codigoColor);
            var linea = await _LineaProduccionRepository.BuscarByAsync(l => l.Nrolinea == nroLinea);

            OrdenProduccion op = new OrdenProduccion(codigoOP, modelo, linea, color);

            return await _OrdenProduccionRepository.AgregarAsync(op);

            // var supervisorLinea = await _SupervisorRepository.BuscarPorIdAsync<Guid>(codigoSupervisor); // SESION DATOS
            //  var supervisorLinea = await _SupervisorRepository.b(codigoSupervisor); // SESION DATOS

            //if ( supervisorLinea.Rol == Rol.SupervisorCalidad) //CAMBIAR LINEA
            //{
            //    throw new Exception("No puede crear un supervisor de calidad la op");
            //}

            //var modelo = _modelRepository.BuscarPorIdAsync(sku);
        }

        public Task<OrdenProduccion> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<OrdenProduccion> GetByCodigoOpAsync(string codigoOP)
        {
            var op = await _OrdenProduccionRepository.BuscarByAsync(op => op.CodigoOP == codigoOP);
            //var color = colores.Where(c => c.CodigoColor == codigoColor)
                           //    .Single();

            if (op == null)
            {
                throw new NullReferenceException();
            }
            /*
            ColorDTO colorDTO = new ColorDTO();
            colorDTO.CodColor = color.CodigoColor;
            colorDTO.Descripcion = color.Descripcion;
            */


            //await Task.WhenAll(modelo, linea, color);
            return op;
        }



        /*
Task<IEnumerable<OrdenProduccion>> IOrdenProduccionService.GetAll()
{
   throw new NotImplementedException();
}*/
    }
}
