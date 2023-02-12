using EmployeeManagementWeb.Common;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementWeb.Data.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Address { get; set; }

        [Required]
        [MaxLength(10)]
        public string? PhoneNumber { get; set; }

        [Required]
        public DepartmentsEnum DepartmentId { get; set; }

    }
}
