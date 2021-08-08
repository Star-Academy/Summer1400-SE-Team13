namespace Phase04
{
    class Program
    {
        static void Main(string[] args)
        {

            var io = new IO();
            var jsonConverter = new JsonConverter();
            var studentsList = jsonConverter.GetDeserializedObjects<Student>(io.GetInput("JsonData/Students.json"));
            var scoresList = jsonConverter.GetDeserializedObjects<Grade>(io.GetInput("JsonData/Scores.json"));
            var scoresOrganizer = new ScoresOrganizer(studentsList, scoresList);
            io.PrintOutput(scoresOrganizer.GetSortedGPAs(),3);
        }
    }
}