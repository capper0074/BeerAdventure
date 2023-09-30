using BeerAdventure.Character;
using BeerAdventure.Sections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerAdventure.Managers
{
    public static class PlayerMovementManager
    {
        public static void MovePlayer(Player player, Section section)
        {
            player.CurrentSection = section;
        }
    }
}
