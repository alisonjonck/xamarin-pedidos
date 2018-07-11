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
        Mock<IProdutoService> mockService;

        IProdutoService service
        {
            get
            {
                return mockService.Object;
            }
        }

        [TestInitialize]
        public void StartUp()
        {
            mockService = new Mock<IProdutoService>();
        }

        [TestMethod]
        public void TestProdutoServiceInterface()
        {
            Assert.IsNotNull(service);
            Assert.IsInstanceOfType(service, typeof(IProdutoService));
        }

        [TestMethod]
        public void TestProdutoServiceInterfaceGetProdutos()
        {
            mockService.Setup(m => m.GetProdutosAsync()).Returns(Task.FromResult(new List<Produto>()));

            var produtos = service.GetProdutosAsync();

            Assert.IsNotNull(produtos);
            Assert.IsInstanceOfType(produtos.Result, typeof(List<Produto>));
        }

        [TestMethod]
        public void TestProdutoServiceInterfaceGetCategorias()
        {
            mockService.Setup(m => m.GetCategoriasAsync()).Returns(Task.FromResult(new List<Categoria>()));

            var categorias = service.GetCategoriasAsync();

            Assert.IsNotNull(categorias);
            Assert.IsInstanceOfType(categorias.Result, typeof(List<Categoria>));
        }

        [TestMethod]
        public void TestProdutoServiceInterfaceGetPromocoes()
        {
            mockService.Setup(m => m.GetPromocoesAsync()).Returns(Task.FromResult(new List<Promocao>()));

            var promocoes = service.GetPromocoesAsync();

            Assert.IsNotNull(promocoes);
            Assert.IsInstanceOfType(promocoes.Result, typeof(List<Promocao>));
        }
    }
}
