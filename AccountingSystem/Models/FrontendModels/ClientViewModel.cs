using Newtonsoft.Json;

namespace AccountingSystem.Models.FrontendModels
{
    public class ClientViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }
    }
}