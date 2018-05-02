using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopWebApp2.Models
{
    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }
        public int Quantity { get; set; }

        public Product() { }

        public Product(string Name, string Description, double Cost, int Quantity)
        {
            this.Name = Name;
            this.Description = Description;
            this.Cost = Cost;
            this.Quantity = Quantity;
        }

        public Product(int Id, string Name, string Description, double Cost, int Quantity)
        {
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
            this.Cost = Cost;
            this.Quantity = Quantity;
        }

    }
}