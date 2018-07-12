using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pedidos_Domain.Entities;
using Pedidos_Service.Services;
using System.Collections.Generic;
using System.Linq;

namespace Pedidos_Service_Test
{
    [TestClass]
    public class ProdutoServiceTest
    {
        ProdutoService service;

        [TestInitialize]
        public void StartUp()
        {
            service = new ProdutoService();
        }

        [TestMethod]
        public void TestProdutoServiceInstance()
        {
            Assert.IsNotNull(service);
            Assert.IsInstanceOfType(service, typeof(ProdutoService));
        }

        [TestMethod]
        public void TestProdutoServiceGetProdutosShouldReturnListaProdutos()
        {
            var produtos = service.GetProdutosAsync().Result;

            Assert.IsNotNull(produtos);
            Assert.IsInstanceOfType(produtos, typeof(List<Produto>));
            Assert.IsTrue(produtos.Count() > 0);
        }

        [TestMethod]
        public void TestProdutoServiceGetCategoriasShouldReturnListaCategorias()
        {
            var categorias = service.GetCategoriasAsync().Result;

            Assert.IsNotNull(categorias);
            Assert.IsInstanceOfType(categorias, typeof(List<Categoria>));
            Assert.IsTrue(categorias.Count() > 0);
        }

        [TestMethod]
        public void TestProdutoServiceGetCategoriasShouldReturnListaPromocoes()
        {
            var promocoes = service.GetPromocoesAsync().Result;

            Assert.IsNotNull(promocoes);
            Assert.IsInstanceOfType(promocoes, typeof(List<Promocao>));
            Assert.IsTrue(promocoes.Count() > 0);

            foreach (var promocao in promocoes)
            {
                Assert.IsTrue(promocao.Policies.Count() > 0, "Promoção sem política");
            }
        }
    }
}
