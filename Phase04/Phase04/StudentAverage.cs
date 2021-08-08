namespace Phase04
{
    public class StudentAverage
    {
        public Student Student { set; get; }
        public double Average { set; get; }

        public StudentAverage(Student std, double avg)
        {
            Student = std;
            Average = avg;
        }
    }
}