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
        private readonly string _urlAPI = "https://pastebin.com/raw/eVqp7pfX";

        public ProdutoService(string urlAPI = null)
        {
            if (!string.IsNullOrWhiteSpace(urlAPI))
            {
                _urlAPI = urlAPI;
            }
        }

        public async Task<List<Produto>> GetProdutosAsync()
        {
            HttpClient client = new HttpClient();
            var uri = new Uri(_urlAPI);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response;
            response = await client.GetAsync(uri);

            var responseContent = await response.Content.ReadAsStringAsync();

            var produtosVM = JsonConvert.DeserializeObject<List<ProdutoViewModel>>(responseContent);

            var produtos = new List<Produto>();

            foreach (var vm in produtosVM)
            {
                produtos.Add(new Produto(vm.Id, vm.Name, vm.Description, vm.Photo, vm.Price, vm.CategoryId ?? 0));
            }

            return produtos;
        }
    }
}
