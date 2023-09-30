using BeerAdventure.Display;
using BeerAdventure.Managers;

namespace BeerAdventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameStateManager.Initialize();

            // Prepare the adventures section, choices and connections via this initialization.
            Adventure beerAdventure = new();
            beerAdventure.Initialize();

            // Display the starting menu, and thereby, the game.
            Beautifier.ShowStartMenu();
        }
    }
}