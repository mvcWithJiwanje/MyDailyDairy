namespace MyDailyDairy.UI.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MyDailyDairy.UI.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyDailyDairy.UI.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MyDailyDairy.UI.Models.ApplicationDbContext context)
        {
            var manager = new UserManager<ApplicationUser>(
        new UserStore<ApplicationUser>(
            new ApplicationDbContext()));

            for (int i = 0; i < 4; i++)
            {
                var user = new ApplicationUser()
                {
                    UserName = string.Format("Email{0}@mydailydairy.com", i.ToString()),

                    // Add the following so our Seed data is complete:
                    FirstName = string.Format("FirstName{0}", i.ToString()),
                    LastName = string.Format("LastName{0}", i.ToString()),
                    Email = string.Format("Email{0}@mydailydairy.com", i.ToString()),
                };
                manager.Create(user, string.Format("Password{0}", i.ToString()));
            }

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
