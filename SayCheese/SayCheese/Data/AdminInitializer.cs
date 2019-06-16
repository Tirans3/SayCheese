using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace SayCheese.Data
{
    public class AdminInitializer
    {
        public static async Task InitializeAsync(IApplicationBuilder app, IConfigurationRoot config)
        {
            var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

            var roleManager = serviceScope.ServiceProvider.GetRequiredService< RoleManager < IdentityRole >> (); 

            var userManager= serviceScope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();


            string[] roleNames = { "Admin", "User" };
            IdentityResult roleResult;
            foreach (var roleName in roleNames)
            {
                //creating the roles and seeding them to the database
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
            //creating a super user who could maintain the web app
            var Admin = new IdentityUser
            {
                UserName = config.GetSection("AdminSettings")["UserName"]
               
            };
            string AdminPassword = config.GetSection("AdminSettings")["Password"];

            var _user = await userManager.FindByEmailAsync(config.GetSection("AdminSettings")["UserName"]);
            if (_user == null)
            {
                var createPowerUser = await userManager.CreateAsync(Admin, AdminPassword);
                if (createPowerUser.Succeeded)
                {
                    //here we tie the new user to the "Admin" role 
                    await userManager.AddToRoleAsync(Admin, "Admin");
                }
            }
        }
    }
}

