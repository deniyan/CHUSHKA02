using Microsoft.AspNetCore.Identity;

namespace CHUSHKA02.Data.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            Orders = new HashSet<Order>();
        }
        public string UserNamee { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public enum Role
        {
            User,
            Admin
        }
        public ICollection<Order> Orders { get; set; }
    }
}
