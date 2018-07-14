using System;
namespace Pedidos_Domain.Entities
{
    public class ExceptionQuantidade : Exception
    {
        public ExceptionQuantidade(string message)
            : base(message)
        {
        }
    }
}
