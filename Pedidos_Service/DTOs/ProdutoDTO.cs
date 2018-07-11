using Newtonsoft.Json;

namespace Pedidos_Service.DTOs
{
    public class ProdutoDTO
    {
        public ProdutoDTO()
        {
        }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("photo")]
        public string Photo { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("category_id")]
        public int? CategoryId { get; set; }
    }
}
