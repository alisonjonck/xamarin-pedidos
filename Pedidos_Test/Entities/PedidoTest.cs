using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pedidos.Entities;

namespace Pedidos_Test.Entities
{
    [TestClass]
    public class PedidoTest
    {
        [TestMethod]
        public void TestPedidoInstance()
        {
            var pedido = new Pedido();

            Assert.IsNotNull(pedido);
            Assert.IsNotNull(pedido.Id);
            Assert.IsNotNull(pedido.Name);
            Assert.IsNotNull(pedido.Description);
            Assert.IsNotNull(pedido.Photo);
            Assert.IsNotNull(pedido.Price);
            Assert.IsNotNull(pedido.CategoryId);
        }
    }
}
