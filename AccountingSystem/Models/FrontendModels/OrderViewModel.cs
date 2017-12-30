using Newtonsoft.Json;
using System;

namespace AccountingSystem.Models.FrontendModels
{
    public class OrderViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }
    }
}