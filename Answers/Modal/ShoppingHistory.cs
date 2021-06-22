using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
