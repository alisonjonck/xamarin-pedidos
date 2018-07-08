using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pedidos.Entities;

namespace Pedidos_Test.Entities
{
    [TestClass]
    public class CarrinhoTest
    {
        [TestMethod]
        public void TestCarrinhoInstance()
        {
            var carrinho = new Carrinho();

            Assert.IsNotNull(carrinho);
            Assert.IsNotNull(carrinho.Produtos);
            Assert.IsNotNull(carrinho.Total);

            Assert.IsInstanceOfType(carrinho.Produtos, typeof(List<ProdutoCarrinho>));

            Assert.AreEqual(0, carrinho.Total);
        }

        [TestMethod]
        public void TestTotalCarrinhoReturnsSumOfPricesInProdutos()
        {
            var carrinho = new Carrinho();

            carrinho.Produtos.Add(new ProdutoCarrinho(1, "Produto1", 2, "", 10M, 1));

            Assert.AreEqual(20, carrinho.Total);
        }
    }
}
