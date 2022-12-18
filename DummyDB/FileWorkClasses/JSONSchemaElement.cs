using Newtonsoft.Json;

namespace DummyDB
{
    public class JSONSchemaElement
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; private set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; private set; }

        [JsonProperty(PropertyName = "IsPrimary")]
        public bool IsPrimary { get; private set; }
    }
}