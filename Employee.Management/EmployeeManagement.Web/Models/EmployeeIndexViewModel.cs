using EmployeeManagementWeb.Common;
using EmployeeManagementWeb.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementWeb.Models
{
    public class EmployeeIndexViewModel
    {
        public IEnumerable<Employee>? EmployeesList { get; set; }

        public int EmployeeId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Max length 100 characters")]
        public string? Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Max length 100 characters")]
        public string? Address { get; set; }

        [Required]
        [Range(0, 9999999999, ErrorMessage = "Please enter valid Number")]
        [StringLength(10, ErrorMessage = "Length should be 10 characters", MinimumLength = 10)]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Department")]
        public DepartmentsEnum DepartmentId { get; set; }



    }
}
