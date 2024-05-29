using Microsoft.AspNetCore.Identity;

namespace task5.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}