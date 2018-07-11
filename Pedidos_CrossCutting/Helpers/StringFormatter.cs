using System;
using System.Globalization;
using System.Threading;

namespace Pedidos_CrossCutting.Helpers
{
    public static class StringFormatter
    {
        public static string ToBRLCurrency(string text)
        {
            var number = 0M;
            if (Decimal.TryParse(text, out number))
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                var formatted = number.ToString("N2");

                return $"R$ {formatted}";
            }

            throw new Exception("Formato inválido");
        }

    }
}
