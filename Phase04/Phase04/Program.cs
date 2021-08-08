using System.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace Phase04
{
    class Program
    {
        private const string PathStudents = "JsonData/Students.json";
        private const string PathScores = "JsonData/Scores.json";
        static void Main(string[] args)
        {
            const int numberOfStudentsToPrint = 3;
            var io = new IO();
            var jsonConverter = new JsonConverter();
            var studentsList = jsonConverter.GetDeserializedObjects<Student>(io.GetInput(PathStudents));
            var scoresList = jsonConverter.GetDeserializedObjects<Grade>(io.GetInput(PathScores));
            var scoresOrganizer = new ScoresOrganizer(studentsList, scoresList);
            io.PrintOutput(scoresOrganizer.GetSortedGPAs().Take(numberOfStudentsToPrint));
        }
    }
}