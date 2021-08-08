using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Phase04
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

            foreach(var (student, average) in studentsList)
            {
                Console.WriteLine(ConstructOutputString(student, average));
            }
        }

        private string ConstructOutputString(Student student, double GPA)
        {
            return student.FirstName + " " + student.LastName + "       GPA: " + GPA + '\n'; 
        }
    }
}