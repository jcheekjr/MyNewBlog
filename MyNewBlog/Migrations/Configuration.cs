namespace MyNewBlog.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MyNewBlog.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyNewBlog.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MyNewBlog.Models.ApplicationDbContext context)
        {
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
            var roleManager = new RoleManager<IdentityRole>(
            new RoleStore<IdentityRole>(context));

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }

            var userManager = new UserManager<ApplicationUser>(
     new UserStore<ApplicationUser>(context));

            if (!context.Users.Any(u => u.Email == "jcheek.producer@gmail.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "jcheek.producer@gmail.com",
                    Email = "jcheek.producer@gmail.com",
                    FirstName = "James",
                    LastName = "Cheek",
                    DisplayName = "JCHEEK"
                }, "J@mes1");
            }

            var userId = userManager.FindByEmail("jcheek.producer@gmail.com").Id;
            userManager.AddToRole(userId, "Admin");
        }
    }
}
