using Microsoft.AspNetCore.Identity;
using Proiect.DAL.Entities;

namespace Proiect.DAL
{
    public class InitialSeed
    {
        private readonly RoleManager<Role> _roleManager;

        public InitialSeed(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public async void CreateRoles()
        {
            string[] roleNames = {
                                "Admin",
                                "Designer"
                                };
            // int id = 1;
            foreach (var roleName in roleNames)
            {
                var role = new Role
                {
                    Name = roleName,
                    // Id = id++
                };
                _roleManager.CreateAsync(role).Wait();
                //break;
            }
        }
    }
}
