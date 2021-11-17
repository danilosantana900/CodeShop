using CodeShop.Repository.DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CodeShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromServices] DataBase dataBase)
        {
            var result = dataBase.Usuario.ToList();

            if (result.Any())
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(204, string.Empty);
            }
        }
    }
}
