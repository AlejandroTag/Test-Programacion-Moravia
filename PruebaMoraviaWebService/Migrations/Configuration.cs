namespace PruebaMoraviaWebService.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PruebaMoraviaWebService.Models.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PruebaMoraviaWebService.Models.AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //context.Users.AddOrUpdate(
             
            //  new IdentityUser { UserName = "prueba", PasswordHash },
            //  new Person { FullName = "Brice Lambson" },
            //  new Person { FullName = "Rowan Miller" }
            //);

            var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));

            var user = new IdentityUser { UserName = "usuario1@mail.com" };

            userManager.Create(user, "usuario1");

            user = new IdentityUser { UserName = "usuario2@mail.com" };

            userManager.Create(user, "usuario2");

            context.SaveChanges();
            
        }
    }
}
