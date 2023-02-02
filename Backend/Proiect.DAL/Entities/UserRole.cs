using Microsoft.AspNetCore.Identity;

namespace Proiect.DAL.Entities
{
    public class UserRole : IdentityUserRole<int>
    {
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
