using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class ScoresOrganizer
    {
        private readonly List<Student> _studentsList;
        private readonly List<Grade> _scoresList;
        
        public ScoresOrganizer(List<Student> studentsList, List<Grade> scoresList){
            _studentsList = studentsList;
            _scoresList = scoresList;
        }

        private List<Grade> GetStudentsGrades()
        {
            return _studentsList.Join(_scoresList, std => std.StudentNumber, grade => grade.StudentNumber, (std, grade) => grade).ToList();
        }

        public Dictionary<Student, double> SetStudentAverage()
        {
            var studentsGrades = GetStudentsGrades();
            var studentAverageMap = new Dictionary<Student, double>();
            foreach (var student in _studentsList)
            {
                var studentGrades = studentsGrades.Where(grade => grade.StudentNumber == student.StudentNumber).Select(grade => grade.Score);
                studentAverageMap[student] = studentGrades.Average();
            }
            return studentAverageMap;
        }

        public Dictionary<Student, double> GetSortedGPAs()
        {
            return SetStudentAverage().OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }
    }
}