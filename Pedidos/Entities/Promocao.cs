using System.Collections.Generic;

namespace Pedidos.Entities
{
    public class Promocao
    {
        public Promocao()
        {
            Policies = new List<Politica>();
        }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public IList<Politica> Policies { get; set; }
    }
}
