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
        [TestMethod]
        public void TestProdutoServiceInstance()
        {
            ProdutoService service = new ProdutoService();

            Assert.IsNotNull(service);
            Assert.IsInstanceOfType(service, typeof(ProdutoService));
        }

        [TestMethod]
        public void TestProdutoServiceGetProdutosShouldReturnListaProdutos()
        {
            
            
            ProdutoService service = new ProdutoService();

            Assert.IsNotNull(service);
            Assert.IsInstanceOfType(service, typeof(ProdutoService));

            var produtos = service.GetProdutosAsync().Result;

            Assert.IsNotNull(produtos);
            Assert.IsInstanceOfType(produtos, typeof(List<Produto>));
            Assert.IsTrue(produtos.Count() > 0);
        }
    }
}
