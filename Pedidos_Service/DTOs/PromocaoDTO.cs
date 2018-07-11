using System.Collections.Generic;
using Newtonsoft.Json;
using Pedidos_Domain.Entities;

namespace Pedidos_Service.DTOs
{
    public class PromocaoDTO
    {
        public PromocaoDTO()
        {
        }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("category_id")]
        public int CategoryId { get; set; }

        [JsonProperty("policies")]
        public IList<Politica> Policies { get; set; }
    }
}
