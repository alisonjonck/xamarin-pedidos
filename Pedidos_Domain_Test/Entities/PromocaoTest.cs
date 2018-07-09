using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pedidos_Domain.Entities;

namespace Pedidos_Test.Entities
{
    [TestClass]
    public class PromocaoTest
    {
        Promocao promocao;

        [TestInitialize]
        public void StartUp()
        {
            promocao = new Promocao();
        }

        [TestMethod]
        public void TestPromocaoInstance()
        {
            promocao.Name = "Promoção Oi Me Liga";
            promocao.CategoryId = 2;

            Assert.IsNotNull(promocao);
            Assert.IsNotNull(promocao.Name);
            Assert.IsNotNull(promocao.CategoryId);
            Assert.IsNotNull(promocao.Policies);

            Assert.AreEqual("Promoção Oi Me Liga", promocao.Name);
            Assert.AreEqual(2, promocao.CategoryId);
        }

        [TestMethod]
        public void TestPoliciesAcceptsListOfPolitica()
        {
            Assert.IsNotNull(promocao.Policies);
            Assert.IsInstanceOfType(promocao.Policies, typeof(List<Politica>));
        }

        [TestMethod]
        public void TestPromocaoPoliciesMinAndDiscount()
        {
            promocao.Name = "Promoção #100porcentoselfie";
            promocao.CategoryId = 5;

            promocao.Policies.Add(new Politica(2, 10.0M));
            promocao.Policies.Add(new Politica(3, 15.0M));

            Assert.AreEqual("Promoção #100porcentoselfie", promocao.Name);
            Assert.AreEqual(5, promocao.CategoryId);

            Assert.AreEqual(2, promocao.Policies[0].Min);
            Assert.AreEqual(10, promocao.Policies[0].Discount);
            Assert.AreEqual(3, promocao.Policies[1].Min);
            Assert.AreEqual(15, promocao.Policies[1].Discount);
        }
    }
}
