using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerAdventure.Sections;

namespace BeerAdventure.Managers
{
    public class MenuManager
    {
        public MenuManager()
        {
            static void SectionDisplay(Section section)
            {
                if (section != null) 
                {
                    Console.WriteLine(section.Name);
                    Console.WriteLine(section.Description);
                    Console.WriteLine(section.Connections);
                }
            }
        }

    }
}
