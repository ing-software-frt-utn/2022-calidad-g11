using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebControlShoes.Application.Contratos;
using WebControlShoes.Application.DTOs;

namespace WebShoesAPI.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class ColorController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly IColorService _ColorService;
        public ColorController(IConfiguration configuration, IColorService colorService)
        {
            _configuration = configuration;
            _ColorService = colorService;
        }


        [HttpGet]
        [Route("")]
        public string GetIndex()
        {
            return "Controller Color";
        }

        [HttpPost("CreateAsync")]
        public async Task<IActionResult> CrearColorAsync([FromBody] ColorDTO color)
        {
            string codigoColor = color.CodColor;
            string descripcion = color.Descripcion;
            try
            {
                if (codigoColor == null || descripcion is null || descripcion.Equals(string.Empty))
                {
                    throw new ArgumentNullException("Por favor enviar el codigo y la descripcion del color");
                }


               // return Ok(await _ColorService.CrearColor(codigoColor, descripcion));

                using (var stream = new MemoryStream())
                {
                    var colorDTO = await _ColorService.CrearColorAsync(codigoColor, descripcion);
                    //await Task.WhenAll(modelo, linea, color);

                    await JsonSerializer.SerializeAsync(stream, colorDTO, colorDTO.GetType());
                    stream.Position = 0;
                    using var reader = new StreamReader(stream);
                    return Ok(await reader.ReadToEndAsync());
                    //return Ok(await _ColorService.GetById(codigoColor));

                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }


        }




        [HttpGet("Async/{id}")]
        public async Task<IActionResult> GetByIdColorAsync(Guid id)
        {
            try
            {

                using (var stream = new MemoryStream())
                {
                    var colorDTO = await _ColorService.GetByIdAsync(id);

                    await JsonSerializer.SerializeAsync(stream, colorDTO, colorDTO.GetType());
                    stream.Position = 0;
                    using var reader = new StreamReader(stream);
                    return Ok(await reader.ReadToEndAsync());

                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("Async{codigoColor}")]
        public async Task<IActionResult> GetColorAsync(string codigoColor)
        {
            try
            {
                //if (color is null)
                //  {
                //      throw new ArgumentNullException("No se encontro un color con ese codigo");
                //  }
                using (var stream = new MemoryStream())
                {
                    var colorDTO = await _ColorService.GetByCodigoColor(codigoColor);
                    //await Task.WhenAll(modelo, linea, color);

                    await JsonSerializer.SerializeAsync(stream, colorDTO, colorDTO.GetType());
                    stream.Position = 0;
                    using var reader = new StreamReader(stream);
                    return Ok(await reader.ReadToEndAsync());
                    //return Ok(await _ColorService.GetById(codigoColor));

                }

                //return Ok(color);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("AllAsync")]
        public async Task<IActionResult> GetAllColorAsync()
        {
            try
            {
                return  Ok(await _ColorService.GetAllAsync());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        #region Utils
        /*
[HttpGet("{id}")]
public string Get(int id)
{
    return "value";
}*/
        /*

        [HttpPost("Create ")]
       // public async Task<ActionResult> CrearColor([FromBody] ColorDTO color)
        public  IActionResult   CrearColor ([FromBody] ColorDTO color)
        {
            string codigoColor = color.CodColor;
            string descripcion = color.Descripcion;
            try
            {
                if (codigoColor == null || descripcion is null || descripcion.Equals(string.Empty))
                {
                    throw new ArgumentNullException("Por favor enviar el codigo y la descripcion del color");
                }


               // return Ok(await _ColorService.CrearColor(codigoColor, descripcion));

                using (var stream = new MemoryStream())
                {
                    var colorDTO = _ColorService.CrearColor (codigoColor, descripcion);
                    //await Task.WhenAll(modelo, linea, color);

                     JsonSerializer.Serialize (stream, colorDTO, colorDTO.GetType());
                    stream.Position = 0;
                    using var reader = new StreamReader(stream);
                    return Ok(  reader.ReadToEnd ());
                    //return Ok(await _ColorService.GetById(codigoColor));

                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }


        }




        [HttpGet("{codigoColor}")]
        public  IActionResult GetColor(string codigoColor)
        {
            try
            {
                //if (color is null)
                //  {
                //      throw new ArgumentNullException("No se encontro un color con ese codigo");
                //  }
                using (var stream = new MemoryStream())
                {
                    var colorDTO =  _ColorService.GetById(codigoColor);
                    //await Task.WhenAll(modelo, linea, color);

                    JsonSerializer.Serialize(stream, colorDTO, colorDTO.GetType());
                    stream.Position = 0;
                    using var reader = new StreamReader(stream);
                    return Ok( reader.ReadToEnd ());
                    //return Ok(await _ColorService.GetById(codigoColor));

                }

                //return Ok(color);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("All")]
        public  IActionResult GetAllColor ()
        {
            try
            {

                // await color.AsyncState.
                //if (color is null)
                //  {
                //      throw new ArgumentNullException("No se encontro un color con ese codigo");
                //  }

                // var colorDTO=new ColorDTO();
                // colorDTO.CodColor= await color.CodigoColor;
                // colorDTO.Descripcion = await  color.Descripcion;
                // string json = string.Empty;
                // using (var stream = new MemoryStream())
                // {

                return   Ok(  _ColorService.GetAll ());

              //          await JsonSerializer.SerializeAsync(stream, color, color.GetType());
              //          stream.Position = 0;
              //          using var reader = new StreamReader(stream);
              //          return await reader.ReadToEndAsync();
              //  }

                //return Ok(color);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        */

        /*
      
        
        
        [HttpGet("{id}")]
      public string Get(int id)
      {

          return JsonSerializer.Serialize(new ColorDTO());
      }*/


        /*
        // GET: api/<ColorController>
        
        [HttpGet]
        
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ColorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return JsonSerializer.Serialize(new ColorDTO());
        }
        
        // POST api/<ColorController>
        [HttpPost]
        public string Post([FromBody] ColorDTO colorDTO)
        {
            try
            {


                throw new NotImplementedException();
            }
            catch (Exception ex)
            {

                throw new Exception();
            }


        }

        // PUT api/<ColorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ColorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
        #endregion


    }
}
