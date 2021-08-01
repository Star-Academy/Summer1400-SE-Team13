using System;
using System.Collections.Generic;

namespace Phase04
{
    class Student
    {
        public string FirstName {set; get;}
        public string LastName {get; set;}
        public string StudentNumber {get; set;}
        public List<Lesson> lessons {get; set;}
        public double GPA {set; get;}

        Student() {
            GPA = 0;
        }
    }
}