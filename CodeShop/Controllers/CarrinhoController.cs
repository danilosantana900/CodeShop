using CodeShop.Repository.DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CodeShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrinhoController : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = "Cliente")]
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

        [HttpGet]
        [Route("checkout")]
        [Authorize(Roles = "Cliente")]
        public IActionResult GetCheckOut([FromServices] DataBase dataBase)
        {
            var carrinhos = dataBase.Carrinho.Include(x => x.Itens).ThenInclude(i => i.Produto).ToList();


            foreach (var carrinho in carrinhos)
            {
                foreach (var item in carrinho.Itens)
                {
                    carrinho.Total += item.Quantidade * item.Produto.Valor;
                }
                
            }
            if (carrinhos.Any())
            {
                return Ok(carrinhos);
                
            }
            else
            {
                return StatusCode(204, string.Empty);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Cliente")]
        public IActionResult Post([FromBody] Carrinho carrinho, [FromServices] DataBase dataBase)
        {
            var produtosCarrinho = carrinho.Itens.Select(x => x.Produto).Select(x => x.Nome).ToList();
            //foreach (var itm in produtosCarrinho)
            //{
            //    if (!dataBase.Produto.Select(x => x.Nome).Equals(itm))
            //        return StatusCode(404, "Um dos produtos selecionados não está disponível");
            //}
            dataBase.Add(carrinho);

            dataBase.SaveChanges();

            return Ok();
        }

        [HttpDelete("{idCarrinho}/{idItem}")]
        [Authorize(Roles = "Cliente")]
        public IActionResult Delete([FromRoute] int idCarrinho, [FromRoute] int idItem, [FromServices] DataBase dataBase)
        {
            var carrinhoRemover = dataBase.Carrinho.Where(x => x.Id == idCarrinho);
            var itemRemover = carrinhoRemover.Select(x => x.Itens.Where(x => x.Id == idItem).FirstOrDefault());

            dataBase.Item.RemoveRange(itemRemover);

            dataBase.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        [Authorize(Roles = "Cliente")]
        public IActionResult DeleteAll([FromServices] DataBase dataBase)
        {
            var itemRemover = dataBase.Carrinho;

            dataBase.Carrinho.RemoveRange(itemRemover);

            dataBase.SaveChanges();

            return Ok();
        }
    }
}
