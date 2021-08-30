using System;
using System.Collections.Generic;
using System.Text;

namespace INVENTORY_MANAGEMENT
{
    class Inventory
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        public Inventory(string Name, double Price, double Weight)
        {
            this.Name = Name;
            this.Price = Price;
            this.Weight = Weight;
        }
    }
}
