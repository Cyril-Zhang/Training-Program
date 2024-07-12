using EntityFramework.Core.Models.RequestModel;
using EntityFramework.Infrastructure.Services;

namespace EntityFramework.Presentation.UI;

public class ManageEmployee
{
    private EmployeeService _employeeService = new EmployeeService();

    private void AddEmployee()
    {
        EmployeeRequestModel employeeRequestModel = new EmployeeRequestModel();
        Console.WriteLine("Please enter employee name");
        employeeRequestModel.EmployeeName = Console.ReadLine();
        Console.WriteLine("Please enter employee age");
        employeeRequestModel.Age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(_employeeService.AddEmployee(employeeRequestModel));
    }

    private void PrintAllEmployee()
    {
        var employees = _employeeService.GetAllEmployees();
        foreach (var employee in employees)
        {
            Console.WriteLine(employee.EmployeeName+ "\t" + employee.Age);
        }
    }

    private void GetEmployeeById()
    {
        Console.WriteLine("Please enter employee age");
        int id = Convert.ToInt32(Console.ReadLine());
        var employee = _employeeService.GetById(id);
        Console.WriteLine(employee.EmployeeName+ "\t" + employee.Age);
    }

    public void Run()
    {
        PrintAllEmployee();
    }
}