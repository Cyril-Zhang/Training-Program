using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal interface IPersonService
    {
        int CaculateAge();
        decimal CaculateSalary();
        List<string> GetAddresses();
    }
}
