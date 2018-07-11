using System.Collections.Generic;

namespace Pedidos_Domain.Entities
{
    public class Promocao
    {
        public Promocao()
        {
            Policies = new List<Politica>();
        }

        public Promocao(string name, int categoryId, IList<Politica> policies)
        {
            Name = name;
            CategoryId = categoryId;
            Policies = policies;
        }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public IList<Politica> Policies { get; set; }
    }
}
