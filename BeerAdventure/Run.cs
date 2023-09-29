using BeerAdventure.Character;
using BeerAdventure.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerAdventure
{
    public static class Run
    {
        public static void RunGame()
        {

            Player.Initialize();

            Game_Menu.Menu();

        }



    }
}
