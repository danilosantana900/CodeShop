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
        public IActionResult GetAll([FromQuery] string nomeProduto, [FromServices] DataBase dataBase)
        {
            
            if (string.IsNullOrWhiteSpace(nomeProduto))
            {
                return Ok(dataBase.Produto.ToList());
            }
            else
            {
                var resultByName = dataBase.Produto.Where(x => x.Nome == nomeProduto).ToList();

                if (resultByName.Any())
                {
                    return Ok(resultByName);
                }
                else
                {
                    return StatusCode(204, string.Empty);
                }
            }
        }

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

            
        [HttpPost]
        [Authorize(Roles = "Funcionario")]
        public IActionResult Post([FromBody] Produto produto, [FromServices] DataBase dataBase)
        {
            var produtoExiste = dataBase.Produto.Where(x => x.Nome == produto.Nome).ToList(); ;

            if (produtoExiste.Any())
            {
                return StatusCode(409, "Já existe um produto com esse nome na loja.");
            }
            else
            {
                dataBase.Add(produto);
                dataBase.SaveChanges();
                return Ok();
            }
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

            productDb.Descricao = produto.Descricao;

            dataBase.Update(productDb);

            dataBase.SaveChanges();

            return Ok();
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "Funcionario")]
        public IActionResult Delete([FromRoute] int id, [FromServices] DataBase dataBase)
        {

            try
            {
                var productToRemove = dataBase.Produto.Where(x => x.Id == id).FirstOrDefault();

                if (productToRemove == null)
                    return StatusCode(404, $"Product id {id} does not exist");

                dataBase.Produto.RemoveRange(productToRemove);

                dataBase.SaveChanges();

                return Ok();
            }
            catch
            {
                return StatusCode(500, "Erro.");
            }

        }
    }
}
