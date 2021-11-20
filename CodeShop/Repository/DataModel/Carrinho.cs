using System.Collections.Generic;

namespace CodeShop.Repository.DataModel
{
    public class Carrinho
    {
        public int Id { get; set; }
        public float Total { get; set; }
        public virtual ICollection<Item> Itens { get; set; }
    }
}
