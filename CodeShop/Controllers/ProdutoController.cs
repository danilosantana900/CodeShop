using CodeShop.Repository.DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = "Funcionario")]
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
