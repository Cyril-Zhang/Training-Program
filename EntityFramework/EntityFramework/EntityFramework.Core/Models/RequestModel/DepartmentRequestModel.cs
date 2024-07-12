using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Core.Models.RequestModel;

public class DepartmentRequestModel
{
    [Required(ErrorMessage = "DepartmentName is required")]
    [StringLength(256)]
    public string? DepartmentName { get; set; }
    public string? Location { get; set; }
}