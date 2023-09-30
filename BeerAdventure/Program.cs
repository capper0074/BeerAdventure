using BeerAdventure.Managers;

namespace BeerAdventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameStateManager.Initialize();

            Adventure beerAdventure = new();
            beerAdventure.Initialize();
        }
    }
}