using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Pedidos_Domain.Entities;
using Pedidos_Domain.Interfaces;

namespace Pedidos_Domain_Test.Interfaces
{
    [TestClass]
    public class ICatalogoServiceTest
    {
        Mock<ICatalogoService> mockService;

        ICatalogoService service
        {
            get
            {
                return mockService.Object;
            }
        }

        [TestInitialize]
        public void StartUp()
        {
            mockService = new Mock<ICatalogoService>();
        }

        [TestMethod]
        public void TestCatalogoServiceInterface()
        {
            Assert.IsNotNull(service);
            Assert.IsInstanceOfType(service, typeof(ICatalogoService));
        }

        [TestMethod]
        public void TestCatalogoServiceInterfaceGetPromocoes()
        {
            mockService.Setup(m => m.GetPromocoesAsync()).Returns(Task.FromResult(new List<CatalogoPromocao>()));

            var promocoes = service.GetPromocoesAsync();

            Assert.IsNotNull(promocoes);
            Assert.IsInstanceOfType(promocoes.Result, typeof(List<CatalogoPromocao>));
        }
    }
}
