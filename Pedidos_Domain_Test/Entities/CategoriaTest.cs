using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pedidos_Domain.Entities;

namespace Pedidos_Test.Entities
{
    [TestClass]
    public class CategoriaTest
    {
        [TestMethod]
        public void TestCategoriaInstance()
        {
            var categoria = new Categoria(5, "Câmeras fotográficas");

            Assert.IsNotNull(categoria);
            Assert.AreEqual(5, categoria.Id);
            Assert.AreEqual("Câmeras fotográficas", categoria.Name);
        }
    }
}
