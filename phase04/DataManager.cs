using System.Collections.Generic;
using System.Text.Json;


namespace phase04
{
    class DataManager
    {
        public List<T> DeserializeObject<T>(string json)
        {
            return JsonSerializer.Deserialize<List<T>>(json);
        }
    }
}