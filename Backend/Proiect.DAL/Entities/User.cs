using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Proiect.DAL.Entities
{
    public class User : IdentityUser<int>
    {
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
