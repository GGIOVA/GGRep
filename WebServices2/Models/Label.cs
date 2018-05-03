using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServices2.Models
{
    public class Label
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Length { get; set; }

        public Label(string Name, string Description)
        {
            this.Name = Name;
            this.Description = Description;
            Length = Description.Length;
        }
    }
}