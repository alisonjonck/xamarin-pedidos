using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pedidos.Entities;

namespace Pedidos_Test.Entities
{
    [TestClass]
    public class PromocaoTest
    {
        [TestMethod]
        public void TestPromocaoInstance()
        {
            Assert.IsNotNull(new Promocao());
        }
    }
}
