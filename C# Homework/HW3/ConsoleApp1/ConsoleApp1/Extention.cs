using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Extention
    {
        public static int CountEmployee(this List<Employee> employees)
        {
            int count = 0;
            foreach (var item in employees)
            {
                count = count + 1;
            }
            return count;
        }
    }
}
