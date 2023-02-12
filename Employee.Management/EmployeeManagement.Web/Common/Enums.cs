using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementWeb.Common
{
    public enum DepartmentsEnum
    {
        [Display(Name = "IT")]
        IT = 1,
        [Display(Name = "Business")]
        Business = 2,
        [Display(Name = "Marketing")]
        Marketing = 3
    }
}
