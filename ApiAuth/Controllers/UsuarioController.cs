using ApiAuth.Model;
using ApiAuth.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        [Route("lista")]
        [AllowAnonymous]
        public List<Usuario> GetUsuarios()
        {
            return new UserRepository().GetList();
        }

        [HttpPost]
        [Route("adduser")]
        [Authorize(Roles ="Admin")]
        public dynamic CadastrarUsuario(Usuario usuario)
        {
            var user = new UserRepository().Add(usuario);
            return new
            {
                id = user.Id,
                nome = user.UserName
            };
        }

    }
}
