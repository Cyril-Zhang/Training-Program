using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Course : ICourseService
    {
        public string name { get; set; }
        public List<Student> EnrolledStudents { get; set; }
        public List<Student> GetEnrolledStudents()
        {
            return EnrolledStudents;
        }
    }
}
