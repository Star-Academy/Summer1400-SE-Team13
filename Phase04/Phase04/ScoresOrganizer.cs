using System.Collections.Generic;
using System.Linq;

namespace Phase04
{
    public class ScoresOrganizer
    {
        private readonly IEnumerable<Student> _studentsList;
        private readonly IEnumerable<Grade> _scoresList;
        
        public ScoresOrganizer(IEnumerable<Student> studentsList, IEnumerable<Grade> scoresList){
            _studentsList = studentsList;
            _scoresList = scoresList;
        }

        private IEnumerable<StudentAverage> GetStudentsAverage()
        {
            var studentsAverage = _studentsList.GroupJoin(_scoresList,
                std => std.StudentNumber,
                grade => grade.StudentNumber,
                (std, grade) => new StudentAverage(std, grade.Select(grd => grd.Score).Average()));
            return studentsAverage;
        }

        // private Dictionary<Student, double> GetStudentAverage()
        // {
        //     var studentsGrades = GetStudentsGrades();
        //     var studentAverage = _studentsList.Select(s =>
        //         new
        //         {
        //             Student = s,
        //             Average = studentsGrades.Where(p => p.StudentNumber == s.StudentNumber).Select(x => x.Score)
        //                 .Average()
        //         }).ToDictionary(x => x.Student, x => x.Average);
        //     return studentAverage;
        // }

        public IEnumerable<StudentAverage> GetSortedGPAs()
        {
            return GetStudentsAverage().OrderByDescending(student => student.Average);
        }
    }
}