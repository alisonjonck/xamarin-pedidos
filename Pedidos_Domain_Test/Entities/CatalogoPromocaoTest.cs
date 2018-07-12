using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pedidos_Domain.Entities;

namespace Pedidos_Domain_Test.Entities
{

    [TestClass]
    public class CatalogoPromocaoTest
    {
        CatalogoPromocao catalogo;

        [TestInitialize]
        public void StartUp()
        {
            catalogo = new CatalogoPromocao();
        }

        [TestMethod]
        public void TestCatalogoPromocaoInstance()
        {
            Assert.IsNotNull(catalogo);

            Assert.IsNotNull(catalogo.Promocao);
            Assert.IsInstanceOfType(catalogo.Produtos, typeof(List<Produto>));
        }

        [TestMethod]
        public void TestCatalogoGetPrecoPromocao()
        {
            var politicas = new List<Politica>();
            politicas.Add(new Politica(5, 10));

            catalogo.Promocao = new Promocao("Teste sem desconto", 1, politicas);

            catalogo.Produtos.Add(new Produto()
            {
                Id = 1,
                Price = 10M,
                CategoryId = 1
            });

            decimal precoDesconto = catalogo.GetPrecoPromocao(quantidade: 2, produtoId: 1);

            Assert.IsNotNull(precoDesconto);
            Assert.AreEqual(20M, precoDesconto);
        }

        [TestMethod]
        public void TestCatalogoGetPrecoPromocaoAppliesPolicy()
        {
            var politicas = new List<Politica>();
            politicas.Add(new Politica(5, 10));

            catalogo.Promocao = new Promocao("Teste desconto 10%", 1, politicas);

            catalogo.Produtos.Add(new Produto()
            {
                Id = 1,
                Price = 10M,
                CategoryId = 1
            });

            decimal precoDesconto = catalogo.GetPrecoPromocao(quantidade: 5, produtoId: 1);

            Assert.IsNotNull(precoDesconto);
            Assert.AreEqual(45M, precoDesconto);

            politicas.Add(new Politica(10, 20));

            catalogo.Promocao = new Promocao("Teste desconto 20%", 1, politicas);

            precoDesconto = catalogo.GetPrecoPromocao(quantidade: 10, produtoId: 1);

            Assert.AreEqual(80M, precoDesconto);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestProdutoMustBeAttachedToCategoriaPromocao()
        {
            var politicas = new List<Politica>();
            politicas.Add(new Politica(5, 10));

            catalogo.Promocao = new Promocao("Teste Produto Categoria pertence a promoção", categoryId: 1, policies: politicas);

            catalogo.Produtos.Add(new Produto()
            {
                Id = 1,
                Price = 10M,
                CategoryId = 2
            });

            decimal precoDesconto = catalogo.GetPrecoPromocao(quantidade: 1, produtoId: 1);
        }
    }
}
