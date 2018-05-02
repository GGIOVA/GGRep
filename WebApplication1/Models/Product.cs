using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Product
    {

        public Product() { }
        public Product(string nome, double prezzo)
        {
            this.Nome = nome;
            this.Prezzo = prezzo;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public double Prezzo { get; set; }
    }

    public class ProdottoContext : DbContext
    {
        public ProdottoContext() : base("ProductContext")
        {
        }
        public DbSet<Product> Prodotti { get; set; }

        public DbSet<RoleViewModel> RoleViewModels { get; set; }
    }

    public class ProdottoInitializer : DropCreateDatabaseIfModelChanges<ProdottoContext>
    {
        protected override void Seed(ProdottoContext context)
        {
            var Prodotti = new List<Product>
            {
                new Product("Crema", 20)
        };
            Prodotti.ForEach(p => context.Prodotti.Add(p));
            context.SaveChanges();
        }
    }
}