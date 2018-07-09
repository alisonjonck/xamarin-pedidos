using System.Collections.Generic;
using System.Linq;

namespace Pedidos_Domain.Entities
{
    public class Carrinho
    {
        public Carrinho()
        {
            Produtos = new List<ProdutoCarrinho>();
        }

        public IList<ProdutoCarrinho> Produtos { get; set; }

        public decimal Total
        {
            get
            {
                return Produtos.Sum(p => p.Price * p.Quantity);
            }
        }
    }
}
