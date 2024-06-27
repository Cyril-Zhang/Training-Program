using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Instructor: Person, IInstructorService
    {
        public string department { get; set; }
        public DateTime startDate { get; set; }
        public bool isHead { get; set; }

        public decimal bounds { get; set; }

        public override decimal CaculateSalary()
        {
            int experiencedYear = this.CalculateYearsOfExperience();
            return Salary+ experiencedYear*this.bounds;
        }

        public int CalculateYearsOfExperience()
        {
            return (int) DateTime.Now.Year - startDate.Year;
        }
    }
}
