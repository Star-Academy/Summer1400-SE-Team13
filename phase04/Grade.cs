namespace phase04
{
    class Grade 
    {   
        
        public int StudentNumber {get; set;}
        public string Lesson {get; set;}
        public double Score {get; set;}

        public Grade(int studentNumber, string lesson, double score)
        {
            Score = score;
            Lesson = lesson;
            StudentNumber = studentNumber;
        }
    } 
}