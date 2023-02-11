using Microsoft.AspNetCore.Identity;

namespace EmployeeManagementWeb.Data.Entities
{
    public class CustomIdentityUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Gender { get; set; }
    }
}
