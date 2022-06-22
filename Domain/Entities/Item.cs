using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Link { get; set; }

        public Item(int id, string name, double price, string link) 
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Link = link;  
        }

    }
}