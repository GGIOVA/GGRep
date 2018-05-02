namespace ShopWebApp.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using ShopWebApp.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ShopWebApp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "ShopWebApp.Models.ApplicationDbContext";
        }

        protected override void Seed(ShopWebApp.Models.ApplicationDbContext context)
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

            // Aggiungo l'utente admin
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new ApplicationUserManager(userStore);

            var user = context.Users.FirstOrDefault(u => u.UserName == "lorenzo@lorenzo.com");
            if (user == null)
            {
                user = new ApplicationUser()
                {
                    UserName = "lorenzo@lorenzo.com",
                    Email = "lorenzo@lorenzo.com",
                    EmailConfirmed = false,
                    LockoutEnabled = true
                };

                var password = "Lorenzo123!";
                userManager.Create(user, password);
            }

            context.SaveChanges();

            // Aggiungo Prodotti
            context.Products.AddOrUpdate(

                new Product(1,"Ciao", 10.0, 15),
                new Product(2,"Bella", 12.0, 151),
                new Product(3,"We", 5.0, 27),
                new Product(4,"Yo", 7.0, 29),
                new Product(5,"Fra", 11.0, 25)
            );

            context.SaveChanges();

            // Aggiungo il ruolo admin
            IdentityRole NewRole = context.Roles.Where(x => x.Name == "Admin").FirstOrDefault();
            if (NewRole == null)
            {
                NewRole = new IdentityRole("Admin");
                context.Roles.AddOrUpdate(NewRole);
                context.SaveChanges();
            }
            
            // Assegno il ruolo admin all'utente admin
            userManager.AddToRole(user.Id, NewRole.Name);
            context.SaveChanges();
        }
    }
}
