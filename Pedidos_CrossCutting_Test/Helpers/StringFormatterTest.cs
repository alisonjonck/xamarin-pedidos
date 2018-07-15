using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pedidos_CrossCutting.Helpers;

namespace Pedidos_CrossCutting_Test.Helpers
{
    [TestClass]
    public class StringFormatterTest
    {
        [TestMethod]
        public void TestStringFormatterHasBRLCurrencyFormat()
        {
            Assert.IsNotNull(StringFormatter.ToBRLCurrency("0"));
        }

        [TestMethod]
        public void TestStringFormatterBRLCurrencyFormatShouldFormat()
        {
            var valorEmReais = StringFormatter.ToBRLCurrency("10");

            Assert.IsNotNull(valorEmReais);
            Assert.AreEqual("10,00", valorEmReais);
        }

        [TestMethod]
        public void TestStringFormatterBRLCurrencyFormatShouldNotFormat()
        {
            Assert.ThrowsException<Exception>(() => {
                
                var valor = StringFormatter.ToBRLCurrency("ABC");

            });
        }

        [TestMethod]
        public void TestBRLCurrencyFormatShouldAddDots()
        {
            var valorEmReais = StringFormatter.ToBRLCurrency("1000");

            Assert.IsNotNull(valorEmReais);
            Assert.AreEqual("1.000,00", valorEmReais);
        }

    }
}
