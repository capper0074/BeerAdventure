using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BeerAdventure.Character
{
    public static class Player
    {
        public static int Stamina { get; set; }

        public static int Health { get; set; }

        public static string Name { get; set; }

        private static bool isInitialize;

        public static void Initialize()
        {
            if (isInitialize)
            {
                return;
            }
            else
            {
                Health = 100;
                Stamina = 100;
                isInitialize = true;
            }
        }

        public static void Display_Stats()
        {
            Console.WriteLine("Hi " + Player.Name + " Your current Stamina are: " + Player.Stamina + " And your health are: " + Player.Health);
        }

        public static void Eat()



    }
}
