using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopWebApp.Models
{
    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public int Quantity { get; set; }

        public Product()
        {

        }

        public Product(string name, double cost, int quantity)
        {
            this.Name = name;
            this.Cost = cost;
            this.Quantity = quantity;
        }

        public Product(int id, string name, double cost, int quantity)
        {
            this.Id = Id;
            this.Name = name;
            this.Cost = cost;
            this.Quantity = quantity;
        }
    }
}