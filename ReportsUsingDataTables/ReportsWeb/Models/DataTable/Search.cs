using Newtonsoft.Json;

namespace ReportsWeb.Models.DataTable
{
    public sealed class Search
    {
        [JsonProperty(PropertyName = "regex")]
        public bool Regex { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
    }
}
