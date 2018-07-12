using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pedidos_Domain.Entities;
using Pedidos_Service.Services;

namespace Pedidos_Service_Test
{
    [TestClass]
    public class CatalogoServiceTest
    {
        CatalogoService service;

        [TestInitialize]
        public void StartUp()
        {
            service = new CatalogoService();
        }

        [TestMethod]
        public void TestCatalogoServiceInstance()
        {
            Assert.IsNotNull(service);
            Assert.IsInstanceOfType(service, typeof(CatalogoService));
        }

        [TestMethod]
        public void TestCatalogoServiceGetPromocoesShouldReturnCatalogoPromocoes()
        {
            var catalogos = service.GetPromocoesAsync().Result;

            Assert.IsNotNull(catalogos);
            Assert.IsInstanceOfType(catalogos, typeof(List<CatalogoPromocao>));
            Assert.IsTrue(catalogos.Count() > 0);
        }
    }
}
