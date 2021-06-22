using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Answers.Modal
{
    public partial class Product
    {
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("price")]
        public double price { get; set; }

        [JsonProperty("quantity")]
        public double quantity { get; set; }
    }
}