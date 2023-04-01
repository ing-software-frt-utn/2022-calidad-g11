using Microsoft.AspNetCore.Mvc;
using WebControlShoes.Application.Contratos;
using WebControlShoes.Application.Servicios;
using Zapatillas.Domain.Entities;

namespace WebShoesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InspeccionarController : Controller
    {

        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly IInspeccionarService _inspeccionarService;
        public InspeccionarController(IConfiguration configuration, IInspeccionarService inspeccionarService )
        {
            _configuration = configuration;
            _inspeccionarService = inspeccionarService;
       //     _ColorService = colorService;
        }


        [HttpPut("RegistrarIncidencia")]
        public async Task<IActionResult> RegistrarIncidencia(string codigoOP, Guid defectoId,
                                           Pie pie, TipoDefecto tipo , int quantity = 1)
        {
            try
            {
                
                    await _inspeccionarService.RegistrarDefecto(codigoOP, defectoId, pie, tipo, 10, quantity);
                    return Ok("se ejecuto con exito");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("InspeccionarCalzado")]
        public async Task<IActionResult> InspeccionarCalzado(string supervisorCalidad, string codigoOP)
        {
            try
            {
                    await _inspeccionarService.IniciarInspeccionAsync(supervisorCalidad, codigoOP);
                    return Ok("se ejecuto con exito");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





    }
}
