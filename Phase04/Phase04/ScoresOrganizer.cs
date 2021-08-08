using System.Collections.Generic;
using System.Linq;

namespace Phase04
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
            List<Grade> studentsGrades = _studentsList.Join(_scoresList, std => std.StudentNumber, grade => grade.StudentNumber, (std, grade) => grade).ToList();
            return studentsGrades;
        }

        private Dictionary<Student, double> SetStudentAverage()
        {
            var studentsGrades = GetStudentsGrades();
            var studentAverage = _studentsList.Select(s =>
                new {
                Student = s,
                Average = studentsGrades.Where(p => p.StudentNumber == s.StudentNumber).Select(x => x.Score).Average()
                 }).ToDictionary(x => x.Student, x => x.Average);
            return studentAverage;
        }

        public Dictionary<Student, double> GetSortedGPAs()
        {
            return SetStudentAverage().OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }
    }
}