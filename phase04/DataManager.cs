using System.Collections.Generic;
using System.Text.Json;


namespace phase04
{
    class DataManager
    {
        public DataManager() 
        {
        }
        public List<Student> GetStudentsData(string json)
        {
            return JsonSerializer.Deserialize<List<Student>>(json);
        }
        
        public List<Grade> GetScoresData(string json) 
        {
            return JsonSerializer.Deserialize<List<Grade>>(json);
        }
    }
}