using Azure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using TheBuzzerBeater.DataAccess.Data;
using TheBuzzerBeater.Models;
using TheBuzzerBeater.Utilities;

namespace TheBuzzerBeater.DataAccess.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;

        public DbInitializer(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext db)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;
        }
        public void Initialize()
        {

            //migrations if they are not applied
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {

            }

            //create roles if they are not created

            if (!_roleManager.RoleExistsAsync(StaticDetails.Role_Customer).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(StaticDetails.Role_Customer)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(StaticDetails.Role_Employee)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(StaticDetails.Role_Admin)).GetAwaiter().GetResult();

                // if roles are not created,then we will create admin user as well
            
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "admin@theBuzzerBeater.com",
                    Email = "admin@theBuzzerBeater.com",
                    FirstName = "Admin",
                    LastName = "Admin",
                    PhoneNumber = "2105149634",
                    StreetAddress = "Mesogeion 156 ",
                    PostalCode = "10498",
                    State = "Attica",
                    City = "Athens",
                    Country = "Greece",
                    EmailConfirmed = true,
                },"Admin!123").GetAwaiter().GetResult();

                ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "admin@theBuzzerBeater.com");

                _userManager.AddToRoleAsync(user, StaticDetails.Role_Admin).GetAwaiter().GetResult();
            }
            return;
        }
    }
}

