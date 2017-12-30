using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AccountingSystem.Models.FrontendModels
{
    public class ClientCardViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("bDay")]
        public DateTime BDay { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("totalAmount")]
        public decimal TotalAmount { get; set; }

        [JsonProperty("orders")]
        public IEnumerable<OrderViewModel> Orders { get; set; }
    }
}