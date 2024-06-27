using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    public class Student : Person, IStudentService
    {

        public List<Course> courses = new List<Course>();
        public override decimal CaculateSalary()
        {
            return 0;
        }

        public double CalculateGPA(List<string> grades)
        {
            double totalPoints = 0;
            foreach (string grade in grades)
            {
                switch (grade)
                {
                    case "A": totalPoints += 4; break;
                    case "B": totalPoints += 3; break;
                    case "C": totalPoints += 2; break;
                    case "D": totalPoints += 1; break;
                    case "F": totalPoints += 0; break;
                }
            }
            return totalPoints/grades.Count;
        }
    }
}
