using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Pedidos_Domain.Entities;
using Pedidos_Domain.Interfaces;

namespace Pedidos_Test.Interfaces
{
    [TestClass]
    public class IProdutoServiceTest
    {
        [TestMethod]
        public void TestProdutoServiceInterfaceGetProdutos()
        {
            Mock<IProdutoService> mockService = new Mock<IProdutoService>();

            mockService.Setup(m => m.GetProdutosAsync()).Returns(Task.FromResult(new List<Produto>()));

            var service = mockService.Object;

            Assert.IsNotNull(service);
            Assert.IsInstanceOfType(service, typeof(IProdutoService));

            var produtos = service.GetProdutosAsync();

            Assert.IsNotNull(produtos);
            Assert.IsInstanceOfType(produtos.Result, typeof(List<Produto>));
        }
    }
}
