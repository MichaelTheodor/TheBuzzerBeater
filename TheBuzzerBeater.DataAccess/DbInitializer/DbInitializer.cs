using Azure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;

        public DbInitializer(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext db,
        IConfiguration configuration)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;
            _configuration = configuration;
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
                Console.WriteLine("Migration failed: " + ex.Message);
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
                    UserName = _configuration["AdminUser:Email"],
                    Email = _configuration["AdminUser:Email"],
                    FirstName = _configuration["AdminUser:FirstName"],
                    LastName = _configuration["AdminUser:LastName"],
                    PhoneNumber = _configuration["AdminUser:PhoneNumber"],
                    StreetAddress = _configuration["AdminUser:StreetAddress"],
                    PostalCode = _configuration["AdminUser:PostalCode"],
                    State = _configuration["AdminUser:State"],
                    City = _configuration["AdminUser:City"],
                    Country = _configuration["AdminUser:Country"],
                    EmailConfirmed = true,
                }, _configuration["AdminUser:Password"]).GetAwaiter().GetResult();

                ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(u => u.Email == _configuration["AdminUser:Email"]);

                _userManager.AddToRoleAsync(user, StaticDetails.Role_Admin).GetAwaiter().GetResult();
            }
            return;
        }
    }
}

