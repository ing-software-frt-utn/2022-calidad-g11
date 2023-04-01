using Microsoft.AspNetCore.Mvc;
using WebControlShoes.Application.Contratos;

namespace WebShoesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdenProduccionController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly IOrdenProduccionService _OrdenProduccionService;
        
        public OrdenProduccionController(IConfiguration configuration, IOrdenProduccionService OrdenProduccionService)
        {
            _configuration = configuration;
            _OrdenProduccionService= OrdenProduccionService;
        }




        [HttpPost("Create")]
        // public async Task<ActionResult> CrearColor([FromBody] ColorDTO color)
        public  async Task<IActionResult> CrearOrdenProduccion(string codigoColor, string sku, string codigoOP,int nroLinea, string codigoSupervisor)
        {
            try
            {
               /* if (codigoColor == null || descripcion is null || descripcion.Equals(string.Empty))
                {
                    throw new ArgumentNullException("Por favor enviar el codigo y la descripcion del color");
                }*/


                return Ok(await _OrdenProduccionService.CrearOrdenProduccionAsync(codigoColor, nroLinea, sku, codigoOP,codigoSupervisor));
            }
            catch (Exception ex)
            {
                return  BadRequest(ex.Message);
            }


        }


        [HttpGet("All")]
        public async Task<IActionResult> GetAllOrdenesProduction()
        {
            try
            {

                return Ok(await _OrdenProduccionService.GetAll());

                //          await JsonSerializer.SerializeAsync(stream, Model, Model.GetType());
                //          stream.Position = 0;
                //          using var reader = new StreamReader(stream);
                //          return await reader.ReadToEndAsync();
                //  }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        /*
        [HttpGet("{codigoColor}")]
        public async Task<IActionResult> GetIndex(string codigoColor)
        {
            return Ok(await _ColorService.GetById(codigoColor));
        }
        */

    }
}
