using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Pedidos_Domain.Entities;
using Pedidos_Domain.Interfaces;
using Pedidos_Service.DTOs;

namespace Pedidos_Service.Services
{
    public class ProdutoService : IProdutoService
    {
        readonly string _urlProdutos = "https://pastebin.com/raw/eVqp7pfX";
        readonly string _urlCategorias = "http://pastebin.com/raw/YNR2rsWe";
        readonly string _urlPromocoes = "https://pastebin.com/raw/R9cJFBtG";

        public ProdutoService(string urlProdutos = null, string urlCategorias = null, string urlPromocoes = null)
        {
            if (!string.IsNullOrWhiteSpace(urlProdutos))
            {
                _urlProdutos = urlProdutos;
            }
            if (!string.IsNullOrWhiteSpace(urlCategorias))
            {
                _urlCategorias = urlCategorias;
            }
            if (!string.IsNullOrWhiteSpace(urlPromocoes))
            {
                _urlPromocoes = urlPromocoes;
            }
        }

        public async Task<List<Categoria>> GetCategoriasAsync()
        {
            var categorias = await GetListOfAsync<Categoria>(_urlCategorias);

            return categorias;
        }

        public async Task<List<Produto>> GetProdutosAsync()
        {
            var produtosVM = await GetListOfAsync<ProdutoDTO>(_urlProdutos);

            var produtos = new List<Produto>();

            foreach (var vm in produtosVM)
            {
                produtos.Add(new Produto(vm.Id, vm.Name, vm.Description, vm.Photo, vm.Price, vm.CategoryId ?? 0));
            }

            return produtos;
        }

        public async Task<List<Promocao>> GetPromocoesAsync()
        {
            var promocoesVM = await GetListOfAsync<PromocaoDTO>(_urlPromocoes);

            var promocoes = new List<Promocao>();

            foreach (var vm in promocoesVM)
            {
                promocoes.Add(new Promocao(vm.Name, vm.CategoryId, vm.Policies));
            }

            return promocoes;
        }

        async Task<List<T>> GetListOfAsync<T>(string url)
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
