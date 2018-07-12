using System;
using System.Collections.Generic;
using System.Linq;

namespace Pedidos_Domain.Entities
{
    public class CatalogoPromocao
    {
        public CatalogoPromocao()
        {
            Promocao = new Promocao();
            Produtos = new List<Produto>();
        }

        public Promocao Promocao { get; set; }

        public List<Produto> Produtos { get; set; }

        public decimal GetPrecoPromocao(int quantidade, int produtoId)
        {
            var produto = Produtos.FirstOrDefault(p => p.Id == produtoId);

            if (produto.CategoryId != Promocao.CategoryId)
                throw new Exception($"Produto deve pertencer a categoria Id {Promocao.CategoryId}");

            var politica = GetPoliticaPromocao(quantidade);

            return (produto.Price * (politica != null ? (1 - (politica.Discount / 100)) : 1))
                * quantidade;
        }

        public Politica GetPoliticaPromocao(int quantidade)
        {
            var politica = Promocao.Policies.OrderByDescending(p => p.Min)
                                   .FirstOrDefault(p => p.Min <= quantidade);

            return politica;
        }
    }
}
