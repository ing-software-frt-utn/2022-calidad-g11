using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebControlShoes.Domain.Entities;
using WebControlShoes.Domain.Repository;
using WebShoesAPI.Models;

namespace WebShoesAPI.Controllers
{
    [ApiController]
    [Route("usuario")]
    public class UsuarioController : ControllerBase
    {
        public IConfiguration _Configuration;
        public readonly IRepository<Usuario> _UsuarioRepository;

        public UsuarioController(IConfiguration configuration, IRepository<Usuario> usuarioRepository)
        {
            _Configuration = configuration;
            _UsuarioRepository = usuarioRepository; 
        }


        [HttpPost]
        [Route("login")]
        public  dynamic IniciarSesion([FromBody] Object optData)
        {
         /*   var data = JsonConvert.DeserializeObject<dynamic>(optData.ToString());

            string user = data.NameUsuario.ToString();
            string password = data.Password.ToString();

            //Usuario usuario = Usuario.DB().Where(x => x.nameUsuario == user && x.password == password).FirstOrDefault();

            //Usuario usuario = await _UsuarioRepository.BuscarPorIdAsync(user);
            var usuarios = await _UsuarioRepository.getAllToUseLinq();

            var usuario = Task.FromResult(usuarios.Where(x => x.NameUsuario == user).Single());
           
            
            var jwt = _Configuration.GetSection("Jwt").Get<Jwt>();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("usuario", usuario.NameUsuario)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                jwt.Issuer,
                jwt.Audience,
                claims,
                expires: DateTime.Now.AddDays(180),
                signingCredentials: signIn
                );




            if (usuario == null && !usuario.Password.Equals(password))
            {
                return new
                {
                    success = false,
                    message = "Credenciales Incorrectas",
                    result = ""
                };
            }

            return new
            {
                success = true,
                message = "Exito",
                result = new JwtSecurityTokenHandler().WriteToken(token)
            };
*/
         throw new NotImplementedException();
        }
    }
}
