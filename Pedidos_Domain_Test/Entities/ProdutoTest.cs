using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pedidos_Domain.Entities;

namespace Pedidos_Test.Entities
{
    [TestClass]
    public class ProdutoTest
    {
        Produto produto;

        [TestInitialize]
        public void StartUp()
        {
            produto = new Produto();
        }

        [TestMethod]
        public void TestProdutoInstance()
        {
            produto.Id = 1;
            produto.Name = "32\" Full HD Flat Smart TV H5103 Series 3";

            var descriptionProduto = @"Com o Modo futebol, é como se você estivesse realmente no jogo. 
                Ele exibe, de forma precisa e viva, a grama verde do campo e todas as outras cores do estádio. 
                Um poderoso efeito de som multi-surround também permite que você ouça toda a empolgação. 
                Você pode até mesmo ampliar áreas selecionadas da tela para uma melhor visualização. 
                Com apenas o toque de um botão, você pode aproveitar ao máximo 
                o seu esporte favorito com todos os seus amigos.";

            produto.Description = descriptionProduto;

            produto.Photo = "https://simplest-meuspedidos-arquivos.s3.amazonaws.com/media/imagem_produto/133421/fda44b12-48f7-11e6-996c-0aad52ea90db.jpeg";

            produto.Price = 1466.10M;
            produto.CategoryId = 1;

            Assert.IsNotNull(produto);
            Assert.IsNotNull(produto.Id);
            Assert.IsNotNull(produto.Name);
            Assert.IsNotNull(produto.Description);
            Assert.IsNotNull(produto.Photo);
            Assert.IsNotNull(produto.Price);
            Assert.IsNull(produto.PricePromocao);
            Assert.IsNotNull(produto.CategoryId);
            Assert.IsNotNull(produto.Quantidade);
            Assert.IsNotNull(produto.DescontoPromocao);

            Assert.AreEqual(1, produto.Id);
            Assert.AreEqual("32\" Full HD Flat Smart TV H5103 Series 3", produto.Name);
            Assert.AreEqual(descriptionProduto, produto.Description);
            Assert.AreEqual("https://simplest-meuspedidos-arquivos.s3.amazonaws.com/media/imagem_produto/133421/fda44b12-48f7-11e6-996c-0aad52ea90db.jpeg", produto.Photo);
            Assert.AreEqual(1466.10M, produto.Price);
            Assert.AreEqual(1, produto.CategoryId);
            Assert.AreEqual(0, produto.Quantidade);
            Assert.AreEqual(0, produto.DescontoPromocao);
        }

        [TestMethod]
        public void TestProdutoInstanceShowsNameAndPrice()
        {
            produto.Name = "32\" Full HD Flat Smart TV H5103 Series 3";
            produto.Price = 1466.10M;

            Assert.AreEqual(produto.ToString(), $"{produto.Name} {produto.Price}");
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionQuantidade))]
        public void TestProdutoQuantidadeMinValueShouldBeZero()
        {
            produto.Quantidade = -1;
        }
    }
}
