using Newtonsoft.Json;
using Newtonsoft.Json.Schema;

namespace DummyDB
{
    public class JSONSchema
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; private set; }
        [JsonProperty(PropertyName = "columns")]
        public List<JSONSchemaElement> Elements = new();

        public static JSONSchema FromJsonFile(string path)
        {
            string fileText = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<JSONSchema>(fileText);
        }
    }

}