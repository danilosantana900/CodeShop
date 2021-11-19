namespace CodeShop.Repository.DataModel
{
    public class Item
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
    }
}
