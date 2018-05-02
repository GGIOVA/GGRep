namespace WebApplication1.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApplication1.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication1.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "WebApplication1.Models.ApplicationDbContext";
        }

        protected override void Seed(WebApplication1.Models.ApplicationDbContext context)
        {

            // Aggiungo l'utente admin
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new ApplicationUserManager(userStore);

            var user = context.Users.FirstOrDefault(u => u.UserName == "lorenzo@lorenzo.com");
            if (user == null)
            {
                user = new ApplicationUser()
                {
                    UserName = "gg@mail.it",
                    Email = "gg@mail.it",
                    EmailConfirmed = false,
                    LockoutEnabled = true
                };

                var password = "Reply.2018";
                userManager.Create(user, password);
            }

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

