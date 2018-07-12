namespace Pedidos_Domain.Entities
{
    public class ProdutoPromocao
    {
        public ProdutoPromocao()
        {
            Produto = new Produto();
        }

        public Produto Produto { get; set; }

        public decimal PrecoPromocao { get; set; }
    }
}
