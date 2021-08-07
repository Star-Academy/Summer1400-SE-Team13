using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    public class IO
    {
        public string GetInput(string path)
        {
            if (!File.Exists(path)) throw new Exception("File not found!");
            var fileContent = File.ReadAllText(path);
            return fileContent;
        }
        
        public void PrintOutput(Dictionary<Student, double> studentsList)
        {
            var firstThreeStudents = studentsList.Take(3);
            
            foreach(var student in firstThreeStudents)
            {
                Console.WriteLine(ToString(student.Key, student.Value));
            }
        }

        public string ToString(Student student, double GPA)
        {
            return student.FirstName + " " + student.LastName + "       GPA: " + GPA + '\n'; 
        }
    }
}