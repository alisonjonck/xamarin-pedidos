using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pedidos_Domain.Entities;

namespace Pedidos_Domain_Test.Entities
{

    [TestClass]
    public class CatalogoPromocaoTest
    {
        [TestMethod]
        public void TestCatalogoPromocaoInstance()
        {
            var catalogo = new CatalogoPromocao();

            Assert.IsNotNull(catalogo);

            Assert.IsNotNull(catalogo.Promocao);
            Assert.IsInstanceOfType(catalogo.Produtos, typeof(List<ProdutoPromocao>));
        }
    }
}
