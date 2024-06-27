using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Department: IDepartmentService
    {
        public string DepartmentName { get; set; }
        public Instructor DepartmentHead { get; set; }
        public decimal Budget { get; set; }

        public List<Course> Courses { get; set; }


        public decimal GetBudget()
        {
            return Budget;
        }

        public Instructor GetDepartmentHead()
        {
            return DepartmentHead;
        }

        public List<Course> GetOfferedCourses()
        {
            return Courses;
        }
    }
}
