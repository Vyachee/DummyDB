using Newtonsoft.Json;

namespace DummyDB
{
    public class JSONSchema
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; private set; }
        [JsonProperty(PropertyName = "columns")]
        public List<JSONSchemaElement> Elements = new();
    }

}