using Newtonsoft.Json;

namespace ReportsWeb.Models.DataTable
{
    public sealed class DataOrder
    {
        [JsonProperty(PropertyName = "column")]
        public int Column { get; set; }

        [JsonProperty(PropertyName = "dir")]
        public string Dir { get; set; }
    }
}