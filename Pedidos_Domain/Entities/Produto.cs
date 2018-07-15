using System;

namespace Pedidos_Domain.Entities
{
    public class Produto
    {
        public Produto()
        {
        }

        public Produto(int id, string name, string description, string photo, decimal price, int categoryId)
        {
            Id = id;
            Name = name;
            Description = description;
            Photo = photo;
            Price = price;
            CategoryId = categoryId;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Photo { get; set; }

        public decimal Price { get; set; }

        public decimal? PricePromocao { get; set; }

        public int CategoryId { get; set; }

        int _quantidade = 0;
        public int Quantidade
        {
            get { return _quantidade; }
            set
            {
                if (value < 0)
                    throw new ExceptionQuantidade("Valor mínimo deve ser 0");

                _quantidade = value;
            }

        }

        public decimal DescontoPromocao { get; set; }

        public override string ToString()
        {
            return $"{Name} {Price}";
        }
    }
}
