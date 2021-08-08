using System.Collections.Generic;
using System.Text.Json;

namespace Phase04
{
    public class JsonConverter
    {
        public IEnumerable<T> GetDeserializedObjects<T>(string jsonFileContent)
        {
            return JsonSerializer.Deserialize<IEnumerable<T>>(jsonFileContent);
        }
    }
}