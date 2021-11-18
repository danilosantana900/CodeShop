using CodeShop.Repository.DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult GetAll([FromServices] DataBase dataBase)
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

        [HttpGet]
        [Authorize(Roles = "Funcionario")]
        public IActionResult GetByName([FromRoute] string name, [FromServices] DataBase dataBase)
        {
            var result = dataBase.Produto.Where(x => x.Nome == name);

            if (result.Any())
                return Ok(result);
            else
                return StatusCode(204, string.Empty);
        }

        [HttpGet]
        [Authorize(Roles = "Funcionario")]
        public IActionResult GetById([FromRoute][FromServices] DataBase dataBase)
        {
            var result = dataBase.Produto.Include(x => x.Id).Select(x => x);

            if (result.Any())
                return Ok(result);
            else
                return StatusCode(204, string.Empty);
        }


        //endpoint
        [HttpPost]
        public IActionResult Post([FromBody] Produto produto, [FromServices] DataBase dataBase)
        {
            dataBase.Add(produto);

            dataBase.SaveChanges();

            return Ok();
        }


        [HttpPatch("{id}")]
        public IActionResult Patch([FromRoute] int id, [FromBody] Usuario usuario, [FromServices] DataBase dataBase)
        {
            if (string.IsNullOrWhiteSpace(usuario.Nome))
                return StatusCode(400, $"Missing Parameter {nameof(usuario.Nome)}");

            var personDb = dataBase.Usuario.Where(x => x.Id == id).FirstOrDefault();

            if (personDb == null)
                return StatusCode(404, $"Person id {id} does not exist");

            personDb.Nome = usuario.Nome;
           
            dataBase.Update(personDb);

            dataBase.SaveChanges();

            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id, [FromServices] DataBase dataBase)
        {
            var peopleToRemove = dataBase.Usuario.Where(x => x.Id == id);

            dataBase.Usuario.RemoveRange(peopleToRemove);

            dataBase.SaveChanges();

            return Ok();
        }
    }


}
