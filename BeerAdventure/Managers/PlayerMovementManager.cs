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
        // When a connection is selected, check if it can move there
        //      If the move is okay, then update the players current section and display the new sections menu via the menumanager
        //      If the move is not okay, display some sort of error message (Kasper arbejder på noget lækkert her)

        public static void MovePlayer(Player player, Section section)
        {
            if (player != null && )
            player.CurrentSection = section;
        }
    }
}
