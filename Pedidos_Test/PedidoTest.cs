using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pedidos;

namespace Pedidos_Test
{
    [TestClass]
    public class PedidoTest
    {
        [TestMethod]
        public void TestPedido()
        {
            Assert.IsNotNull(new Pedido());
        }
    }
}
