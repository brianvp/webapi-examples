namespace WebAPIBasicAuthentication.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<WebAPIBasicAuthentication.Models.SecurityDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WebAPIBasicAuthentication.Models.SecurityDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var advancedRole = rm.Create(new IdentityRole("AdvancedUserRole"));

            var um = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));


            var generalUser = new IdentityUser()
            {
                UserName = "5b2025f5c0c847b788545cce506ce6eb"
            };

            IdentityResult ir = um.Create(generalUser, "556038b0a8d943caaf1c1ddfab70f956");

            
            var adminUser = new IdentityUser()
            {
                UserName = "admin"
            };

            ir = um.Create(adminUser, "1234#abcD");

            um.AddToRole(adminUser.Id, "AdvancedUserRole");


            var advancedUser = new IdentityUser()
            {
                UserName = "7f5645122a634577a53dca81359138b6"
            };

            ir = um.Create(advancedUser, "3186b763ddb4405bbf0b0d0eac5892cf");

            um.AddToRole(advancedUser.Id, "AdvancedUserRole");



        }
    }
}
