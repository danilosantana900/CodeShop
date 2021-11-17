using CodeShop.Repository.DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CodeShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrinhoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromServices] DataBase dataBase)
        {
            return Ok();
            //var result = dataBase.Carrinho.Include(x => x.Itens).ToList().Include

            //if (result.Any())
            //{
            //    return Ok(result);
            //}
            //else
            //{
            //    return StatusCode(204, string.Empty);
            //}
        }

        [HttpPost]
        public IActionResult Post([FromBody] Carrinho carrinho, [FromServices] DataBase dataBase)
        {
            dataBase.Add(carrinho);

            dataBase.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id, [FromServices] DataBase dataBase)
        {
            var itemRemover = dataBase.Carrinho.Select(x => x.Itens.Where(x => x.Id == id));

            //dataBase.Carrinho.RemoveRange(itemRemover);

            dataBase.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteAll([FromServices] DataBase dataBase)
        {
            var itemRemover = dataBase.Carrinho;

            dataBase.Carrinho.RemoveRange(itemRemover);

            dataBase.SaveChanges();

            return Ok();
        }
    }
}
