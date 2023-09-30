using BeerAdventure.Display;

namespace BeerAdventure.Managers
{
    public static class GameManager
    {
        public static Adventure BeerAdventure { get; private set; }
        public static BulletMenu StartMenu { get; private set; }

        private static bool _isInitialized = false;

        public static void Initialize()
        {
            if (_isInitialized)
                return;

            // Prepare the adventures section, choices and connections via this initialization.
            Adventure beerAdventure = new();
            beerAdventure.Initialize();

            StartMenu = new();
            StartMenu.MenuItems.Add(new("Embark on an adventure!", () =>
            {
                beerAdventure.Start();
            }));
            StartMenu.MenuItems.Add(new("Give up in advance...", () =>
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("I wasn't up for the task");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
            }));

            _isInitialized = true;
        }
    }
}
