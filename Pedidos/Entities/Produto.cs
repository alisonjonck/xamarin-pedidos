namespace Pedidos.Entities
{
    public class Produto
    {
        public Produto()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Photo { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}
