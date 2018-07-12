using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pedidos_Domain.Entities;
using Pedidos_Domain.Interfaces;
using System.Linq;

namespace Pedidos_Service.Services
{
    public class CatalogoService : ICatalogoService
    {
        readonly ProdutoService _produtoService;
        public CatalogoService()
        {
            _produtoService = new ProdutoService();
        }

        public async Task<List<CatalogoPromocao>> GetPromocoesAsync()
        {
            var promocoes = await _produtoService.GetPromocoesAsync();

            var categoriaIDs = promocoes.Select(p => p.CategoryId).ToArray();

            var produtos = (from produto in (await _produtoService.GetProdutosAsync())
                           where categoriaIDs.Contains(produto.CategoryId)
                           group produto by produto.CategoryId into pg
                           select new CatalogoPromocao()
                           {
                               Promocao = promocoes.FirstOrDefault(x => x.CategoryId == pg.Key),
                               Produtos = pg.Select(c => c).ToList()
                            }).ToList();

            return produtos;
        }
    }
}
