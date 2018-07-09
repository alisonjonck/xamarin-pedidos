namespace Pedidos_Domain.Entities
{
    public class Categoria
    {
        public Categoria(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
