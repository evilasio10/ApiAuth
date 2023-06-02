using ApiAuth.Model;
using ApiAuth.Repositories;
using ApiAuth.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<dynamic>> autenticar(LoginModel auth)
        {
            var user = new UserRepository().Get(auth.UserName, auth.Password);
            if (user == null)
                return NotFound("Usuario ou senha invalidos");
            var token = TokenService.GerarToken(user);
            return new
            {
                usuario = new
                {
                    ide_usuario = user.Id,
                    nome = user.UserName,
                    role = user.Role
                },
                token = token
            };
        }

        [HttpGet]
        [Route("usuarioautenticado")]        
        [Authorize(Roles = "Admin")]
        public string usuarioautenticado()
        {
            return string.Format("Usuario Autenticado é o {0}",User.Identity.Name) ;
        }
    }
}
