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
            var result = dataBase.Carrinho.Include(x => x.Itens).ThenInclude(i => i.Produto).ToList();
            if (result.Any())
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(204, string.Empty);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Carrinho carrinho, [FromServices] DataBase dataBase)
        {
            dataBase.Add(carrinho);

            dataBase.SaveChanges();

            return Ok();
        }

        [HttpDelete("{idCarrinho}/{idItem}")]
        public IActionResult Delete([FromRoute] int idCarrinho, [FromRoute] int idItem, [FromServices] DataBase dataBase)
        {
            var carrinhoRemover = dataBase.Carrinho.Where(x => x.Id == idCarrinho);
            var itemRemover = carrinhoRemover.Select(x => x.Itens.Where(x => x.Id == idItem).FirstOrDefault());

            dataBase.Item.RemoveRange(itemRemover);

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
