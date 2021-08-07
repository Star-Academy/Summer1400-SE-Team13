using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            IO io = new IO();
            JsonConverter jsonConverter = new JsonConverter();
            var studentsList = jsonConverter.DeserializeObject<Student>(io.GetInput("Students.json"));
            var scoresList = jsonConverter.DeserializeObject<Grade>(io.GetInput("Scores.json"));

            ScoresOrganizer scoresOrganizer = new ScoresOrganizer(studentsList, scoresList);
            io.PrintOutput(scoresOrganizer.GetSortedGPAs());
        }
    }
}