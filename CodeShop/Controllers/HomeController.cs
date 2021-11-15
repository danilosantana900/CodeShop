using CodeShop.Repository.DataModel;
using CodeShop.Sevices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeShop.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult<dynamic> Authenticate([FromBody] Usuario usuario, [FromServices] DataBase dataBase)
        {
            var result = dataBase.Usuario.Where(x => x.Nome == usuario.Nome && x.Senha == usuario.Senha).FirstOrDefault();

            if (result == null)
            {
                return NotFound(new { message = "Usuário ou Senha inválidos!" });
            }

            var token = TokenService.GenerateToken(result);
            result.Senha = "";

            return new
            {
                user = result,
                token = token
            };
        }

        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anônimo";

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);

        [HttpGet]
        [Route("funcionario")]
        [Authorize(Roles = "Funcionario")]
        public string Funcionario() => "Funcionário";

        [HttpGet]
        [Route("cliente")]
        [Authorize(Roles = "Cliente")]
        public string Cliente() => "Cliente";
    }
}
