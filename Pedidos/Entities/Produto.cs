﻿namespace Pedidos.Entities
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

        public int CategoryId { get; set; }
    }
}