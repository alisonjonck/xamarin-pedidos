namespace Pedidos_Domain.Entities
{
    public class Politica
    {
        public Politica(int min, decimal discount)
        {
            Min = min;
            Discount = discount;
        }

        public int Min { get; set; }

        public decimal Discount { get; set; }
    }
}
