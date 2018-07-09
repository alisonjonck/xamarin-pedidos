using System.Collections.Generic;
using System.Threading.Tasks;
using Pedidos_Domain.Entities;

namespace Pedidos_Domain.Interfaces
{
    public interface IProdutoService
    {
        Task<List<Produto>> GetProdutosAsync();

        Task<List<Categoria>> GetCategoriasAsync();
    }
}
