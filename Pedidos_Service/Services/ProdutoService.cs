using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Pedidos_Domain.Entities;
using Pedidos_Domain.Interfaces;
using Pedidos_Service.ViewModels;

namespace Pedidos_Service.Services
{
    public class ProdutoService : IProdutoService
    {
        readonly string _urlProdutos = "https://pastebin.com/raw/eVqp7pfX";
        readonly string _urlCategorias = "http://pastebin.com/raw/YNR2rsWe";

        public ProdutoService(string urlProdutos = null, string urlCategorias = null)
        {
            if (!string.IsNullOrWhiteSpace(urlProdutos))
            {
                _urlProdutos = urlProdutos;
            }
            if (!string.IsNullOrWhiteSpace(urlCategorias))
            {
                _urlCategorias = urlCategorias;
            }
        }

        public async Task<List<Categoria>> GetCategoriasAsync()
        {
            var categorias = await GetListOfViewModelOfAsync<Categoria>(_urlCategorias);

            return categorias;
        }

        public async Task<List<Produto>> GetProdutosAsync()
        {
            var produtosVM = await GetListOfViewModelOfAsync<ProdutoViewModel>(_urlProdutos);

            var produtos = new List<Produto>();

            foreach (var vm in produtosVM)
            {
                produtos.Add(new Produto(vm.Id, vm.Name, vm.Description, vm.Photo, vm.Price, vm.CategoryId ?? 0));
            }

            return produtos;
        }

        async Task<List<T>> GetListOfViewModelOfAsync<T>(string url)
        {
            HttpClient client = new HttpClient();
            var uri = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response;
            response = await client.GetAsync(uri);

            var responseContent = await response.Content.ReadAsStringAsync();

            var listVM = JsonConvert.DeserializeObject<List<T>>(responseContent);

            return listVM;
        }
    }
}
