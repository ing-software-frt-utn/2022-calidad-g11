using Microsoft.AspNetCore.Mvc;
using WebControlShoes.Application.Contratos;

namespace WebShoesAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class LineaController : Controller
    {


        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly ILineaService _LineaService;
        public LineaController(IConfiguration configuration, ILineaService colorService)
        {
            _configuration = configuration;
            _LineaService = colorService;
        }


        [HttpGet]
        [Route("")]
        public string GetIndex()
        {
            return "Controller Linea";
        }

        


        [HttpPost("Create")]
        // public async Task<ActionResult> CrearLinea([FromBody] LineaDTO color)
        public async Task<IActionResult> CrearLineaAsync(int nroLinea, string descripcion)
        {
            try
            {
               /* if (codigoLinea == null || descripcion is null || descripcion.Equals(string.Empty))
                {
                    throw new ArgumentNullException("Por favor enviar el codigo y la descripcion del color");
                }*/
                return Ok(await _LineaService.CrearLineaAsync(nroLinea, descripcion));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }


        }
        /*
        [HttpPost("CreateAsync")]
        // public async Task<ActionResult> CrearLinea([FromBody] LineaDTO color)
        public IActionResult CrearLineaAsync(int nroLinea, string descripcion)
        {
            try
            {
               /* if (codigoLinea == null || descripcion is null || descripcion.Equals(string.Empty))
                {
                    throw new ArgumentNullException("Por favor enviar el codigo y la descripcion del color");
                }


                return Ok(  _LineaService.CrearLineaAsync(nroLinea,  descripcion));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }


        }
*/


    }
}
