using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebControlShoes.Application.Contratos;
using WebControlShoes.Application.DTOs;
using WebControlShoes.Application.Servicios;
using Zapatillas.Domain.Entities;

namespace WebShoesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModelController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;

        private readonly IModelService _ModelService;
        public ModelController(IConfiguration configuration, IModelService modelService)
        {
            _configuration = configuration;
            _ModelService = modelService;
        }


        [HttpGet]
        [Route("")]
        public string GetIndex()
        {
            return "Controller Model";
        }



        [HttpGet("AllAsync")]
        public async Task<IActionResult> GetAllModel()
        {
            try
            {

                return Ok(await  _ModelService.GetAllAsync());

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






        //[HttpPost("Create/{sku}/{description}/{limiteObservadoSuperior}/{limiteObservadoInferior}/{limiteReprocesoSuperior}/{limiteReprocesoInferior}")]
        [HttpPost("CreateAsync")]
        // public async Task<IActionResult> CrearModelAsync(string sku, string description, int limiteObservadoSuperior, int limiteObservadoInferior, int limiteReprocesoSuperior, int limiteReprocesoInferior)
        public async Task<ActionResult> CrearModel([FromBody] ModelDTO Model)
        {
            string sku = Model.Sku;
            string description = Model.Name;
            int limiteObservadoSuperior = Model.SuperiorObservado;
            int limiteObservadoInferior = Model.InferiorObservado;
            int limiteReprocesoSuperior = Model.SuperiorReproceso;
            int limiteReprocesoInferior = Model.InferiorReproceso;
            try
            {

                //if (codigoModel == null || descripcion is null || descripcion.Equals(string.Empty))
                //{
                //    throw new ArgumentNullException("Por favor enviar el codigo y la descripcion del Model");
                //}

               // return Ok(await _ModelService.CrearModel(sku, description, limiteObservadoSuperior, limiteObservadoInferior, limiteReprocesoSuperior, limiteReprocesoInferior));
                
                using (var stream = new MemoryStream())
                {
                    var modelDTO = await _ModelService.CrearModelAsync(sku, description, limiteObservadoSuperior, limiteObservadoInferior, limiteReprocesoSuperior, limiteReprocesoInferior);
                    //await Task.WhenAll(modelo, linea, color);

                    await JsonSerializer.SerializeAsync(stream, modelDTO, modelDTO.GetType());
                    stream.Position = 0;
                    using var reader = new StreamReader(stream);
                    return Ok(await reader.ReadToEndAsync());
                    //return Ok(await _ColorService.GetById(codigoColor));

                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }



        [HttpGet("Async{sku}")]
        public async Task<IActionResult> GetModelBySkuAsync(string sku)
        {
            try
            {
                //if (Model is null)
                //  {
                //       return   Ok(await _ModelService.GetAll());
                //  }

                using (var stream = new MemoryStream())
                {
                    var ModelDTO = await _ModelService.GetBySkuAsync(sku);
                    //await Task.WhenAll(modelo, linea, Model);

                    await JsonSerializer.SerializeAsync(stream, ModelDTO, ModelDTO.GetType());
                    stream.Position = 0;
                    using var reader = new StreamReader(stream);
                    return Ok(await reader.ReadToEndAsync());
                    //return Ok(await _ModelService.GetById(codigoModel));

                }

                //return Ok(Model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                //if (Model is null)
                //  {
                //       return   Ok(await _ModelService.GetAll());
                //  }

                using (var stream = new MemoryStream())
                {
                    var ModelDTO = _ModelService.GetByIdAsync(id);
                    //await Task.WhenAll(modelo, linea, Model);

                    //await JsonSerializer.SerializeAsync(stream, ModelDTO, ModelDTO.GetType());
                    //stream.Position = 0;
                    //using var reader = new StreamReader(stream);
                    return Ok(await ModelDTO);
                    //return Ok(await _ModelService.GetById(codigoModel));

                }

                //return Ok(Model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /*
        [HttpGet("{id}")]
        public  async Task<IActionResult>  GetModelAsync(string id)
        {
            try
            {
                //if (Model is null)
                //  {
                //       return   Ok(await _ModelService.GetAll());
                //  }

                using (var stream = new MemoryStream())
                {
                    var ModelDTO =   _ModelService.GetByIdAsync (sku);
                    //await Task.WhenAll(modelo, linea, Model);

                   await  JsonSerializer.SerializeAsync(stream, ModelDTO, ModelDTO.GetType());
                    stream.Position = 0;
                    using var reader = new StreamReader(stream);
                    return Ok( await reader.ReadToEndAsync());
                    //return Ok(await _ModelService.GetById(codigoModel));

                }

                //return Ok(Model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        */


    }
}

        /*
        //[HttpPost("Create/{sku}/{description}/{limiteObservadoSuperior}/{limiteObservadoInferior}/{limiteReprocesoSuperior}/{limiteReprocesoInferior}")]
        [HttpPost("CreateAsync")]
        // public async Task<ActionResult> CrearModel([FromBody] ModelDTO Model)
        public async Task<IActionResult>  CrearModelAsync(string sku, string description, int limiteObservadoSuperior, int limiteObservadoInferior, int limiteReprocesoSuperior, int limiteReprocesoInferior)
        {
            try
            {

                //if (codigoModel == null || descripcion is null || descripcion.Equals(string.Empty))
                //{
                //    throw new ArgumentNullException("Por favor enviar el codigo y la descripcion del Model");
                //}

                // return Ok(await _ModelService.CrearModel(sku, description, limiteObservadoSuperior, limiteObservadoInferior, limiteReprocesoSuperior, limiteReprocesoInferior));

                using (var stream = new MemoryStream())
                {
                    var modelDTO = await _ModelService.CrearModelAsync (sku, description, limiteObservadoSuperior, limiteObservadoInferior, limiteReprocesoSuperior, limiteReprocesoInferior);
                    //await Task.WhenAll(modelo, linea, color);

                    await  JsonSerializer.SerializeAsync (stream, modelDTO, modelDTO.GetType());
                    stream.Position = 0;
                    using var reader = new StreamReader(stream);
                    return  Ok( await reader.ReadToEndAsync());
                    //return Ok(await _ColorService.GetById(codigoColor));

                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }


        }
        */