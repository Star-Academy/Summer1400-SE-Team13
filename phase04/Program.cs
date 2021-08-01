using System;
//using System.String;

namespace phase04
{
    class Program
    {
        static void Main(string[] args)
        {
            string json = File.ReadAllText("Students.json");
            DataManager dm = new DataManager(json);
            var studentsList = dm.getData();
            for(int i = 0; i < studentsList.count; i++){
                Console.WriteLine(studentsList[i].LastName);
            }
        }
    }
}
