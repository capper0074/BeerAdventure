using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerAdventure.Stuff
{
    public class Item
    {

        public string Name { get; set; }

        public string Description { get; set; }
          
        public Size Weight { get; set; }

        public Item(string name, string description, Size weight)
        {
            Name = name;
            Description = description;
            Weight = weight;
        }
    }
}
