using Newtonsoft.Json;

namespace Answers.Modal
{
    public class ShoppingHistory
    {
        [JsonProperty("customerId")]
        public long customerId { get; set; }

        [JsonProperty("products")]
        public Product[] products { get; set; }
    }
}