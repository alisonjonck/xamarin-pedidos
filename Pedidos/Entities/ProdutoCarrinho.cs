namespace Pedidos.Entities
{
    public class ProdutoCarrinho
    {
        public ProdutoCarrinho()
        {
        }

        public ProdutoCarrinho(int id, string name, int quantity, string photo, decimal price, int categoryId)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            Photo = photo;
            Price = price;
            CategoryId = categoryId;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Photo { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public int Quantity { get; set; }
    }
}
