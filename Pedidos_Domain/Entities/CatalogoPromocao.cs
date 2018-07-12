using System.Collections.Generic;

namespace Pedidos_Domain.Entities
{
    public class CatalogoPromocao
    {
        public CatalogoPromocao()
        {
            Promocao = new Promocao();
            Produtos = new List<ProdutoPromocao>();
        }

        public Promocao Promocao { get; set; }

        public List<ProdutoPromocao> Produtos { get; set; }
    }
}
