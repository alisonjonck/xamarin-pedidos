using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pedidos_Domain.Entities;

namespace Pedidos_Domain_Test.Entities
{
    [TestClass]
    public class ProdutoPromocaoTest
    {
        [TestMethod]
        public void TestProdutoPromocaoInstance()
        {
            var produtoPromocao = new ProdutoPromocao();

            Assert.IsNotNull(produtoPromocao);

            Assert.IsNotNull(produtoPromocao.Produto);
            Assert.IsNotNull(produtoPromocao.PrecoPromocao);
        }
    }
}
