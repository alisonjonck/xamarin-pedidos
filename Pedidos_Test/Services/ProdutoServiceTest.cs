using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pedidos_Service;

namespace Pedidos_Test.Services
{
    [TestClass]
    public class ProdutoServiceTest
    {
        [TestMethod]
        public void TestProdutoServiceTest()
        {
            var service = new ProdutoService();

            Assert.IsNotNull(service);
            Assert.IsInstanceOfType(service, typeof(ProdutoService));
        }
    }
}
