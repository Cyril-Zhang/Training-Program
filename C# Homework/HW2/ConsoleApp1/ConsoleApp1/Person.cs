using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class Person: IPersonService
    {
        private string name;
        private DateTime birthdate;
        private decimal salary;
        private List<string> address;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public DateTime Birthdate
        {
            get { return birthdate; }
            set { birthdate = value; }
        }

        public decimal Salary
        {
            get { return salary; }
            set { 
                if(value < 0)
                {
                    throw new ArgumentException("Salary cannot be negative!");
                }
                else
                {
                    salary = value;
                }
            }
        }

        public List<string> Address
        {
            get { return address; }
            set { address = value; }
        }

        public int CaculateAge()
        {
            return (int) DateTime.Now.Year - this.Birthdate.Year;
        }

        public abstract decimal CaculateSalary();

        public List<string> GetAddresses()
        {
            return this.address;
        }
    }
}
