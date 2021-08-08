using System.Collections.Generic;
using System.Text.Json;

namespace Phase04
{
    public class JsonConverter
    {
        public List<T> GetDeserializedObjects<T>(string jsonFileContent)
        {
            return JsonSerializer.Deserialize<List<T>>(jsonFileContent);
        }
    }
}