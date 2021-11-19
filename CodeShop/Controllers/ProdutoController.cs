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
            var result = dataBase.Produto.ToList();

            if (result.Any())
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(204, string.Empty);
            }
        }

        //[HttpGet("{name}")]
        //[Authorize(Roles = "Funcionario")]
        //public IActionResult GetByName([FromRoute] string name, [FromServices] DataBase dataBase)
        //{
        //    var result = dataBase.Produto.Where(x => x.Nome == name);

        //    if (result.Any())
        //        return Ok(result);
        //    else
        //        return StatusCode(204, string.Empty);
        //}

        [HttpGet("{id}")]
        [Authorize(Roles = "Funcionario")]
        public IActionResult GetById([FromRoute] int id, [FromServices] DataBase dataBase)
        {
            var result = dataBase.Produto.Where(x => x.Id == id).FirstOrDefault();

            if (result != null)
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
        [Authorize(Roles = "Funcionario")]
        public IActionResult Patch([FromRoute] int id, [FromBody] Produto produto, [FromServices] DataBase dataBase)
        {
            if (string.IsNullOrWhiteSpace(produto.Nome))
                return StatusCode(400, $"Missing Parameter {nameof(produto.Nome)}");

            if (produto.Valor <= 0)
                return StatusCode(400, $"Missing Value {nameof(produto.Valor)}");

            var productDb = dataBase.Produto.Where(x => x.Id == id).FirstOrDefault();

            if (productDb == null)
                return StatusCode(404, $"Product id {id} does not exist");

            productDb.Nome = produto.Nome;

            productDb.Descricao = produto.Descricao;

            productDb.Valor = produto.Valor;

            dataBase.Update(productDb);

            dataBase.SaveChanges();

            return Ok();
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "Funcionario")]
        public IActionResult Delete([FromRoute] int id, [FromServices] DataBase dataBase)
        {
            var productToRemove = dataBase.Produto.Where(x => x.Id == id).FirstOrDefault();

            dataBase.Produto.RemoveRange(productToRemove);

            dataBase.SaveChanges();

            return Ok();
        }
    }
}
