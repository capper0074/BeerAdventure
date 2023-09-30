using BeerAdventure.Display;
using BeerAdventure.Managers;

namespace BeerAdventure
{
    public class Program
    {
        static void Main(string[] args)
        {
            SectionManager.Initialize();
            GameManager.Initialize();
            GameStateManager.Initialize();

            // Display the title and the starting menu, and thereby, the game.
            Beautifier.DisplayTitle();
            Beautifier.Display(GameManager.StartMenu);
        }
    }
}