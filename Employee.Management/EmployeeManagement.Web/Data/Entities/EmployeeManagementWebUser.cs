using Microsoft.AspNetCore.Identity;

namespace EmployeeManagementWeb.Data.Entities
{
    public class EmployeeManagementWebUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Gender { get; set; }
    }
}
