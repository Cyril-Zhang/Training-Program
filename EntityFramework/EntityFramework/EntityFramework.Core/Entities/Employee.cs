using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Core.Entities;

public class Employee
{
    public int Id { get; set; }
    [MaxLength(50)]
    public string? EmployeeName { get; set; } 
    [Required]
    public int Age { get; set; }
    [Required(ErrorMessage = "The department id field is required")]
    public int DepartmentId { get; set; }
    //navigation property
    public Department Department { get; set; }
}

//Data annotations: provide extra configuration information, validate the input data from the users 
//Fluent Api---> will always take precedence over data annotations