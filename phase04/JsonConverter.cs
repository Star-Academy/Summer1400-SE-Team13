using System.Collections.Generic;
using System.Text.Json;

namespace ConsoleApp1
{
    public class JsonConverter
    {
        public List<T> DeserializeObject<T>(string jsonFileContent)
        {
            return JsonSerializer.Deserialize<List<T>>(jsonFileContent);
        }
    }
}