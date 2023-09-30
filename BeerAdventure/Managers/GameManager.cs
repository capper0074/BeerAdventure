using BeerAdventure.Character;
using BeerAdventure.Display;
using BeerAdventure.Sections;
using SectionName = BeerAdventure.Managers.SectionManager.SectionName;

namespace BeerAdventure.Managers
{
    public static class GameManager
    {
        public static bool IsGameInProgress { get; set; } = false;

        public static Section StartSection { get; set; }
        public static BulletMenu StartMenu { get; private set; }

        private static bool _isInitialized = false;

        public static void Initialize()
        {
            if (_isInitialized)
                return;

            // Prepare the adventures section, choices and connections via this initialization.
            StartSection = SectionManager.GetSection(SectionName.Home);

            StartMenu = new();
            StartMenu.MenuItems.Add(new("Embark on an adventure!", new(() => Start())));
            StartMenu.MenuItems.Add(new("Stay home, stay safe...", () =>
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("I chose to stay home... Knowing that I will never know what true beer tastes like.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
            }));

            _isInitialized = true;
        }

        public static void Start()
        {
            IsGameInProgress = true;

            Player.CurrentSection = StartSection;

            do
            {
                Beautifier.Display(Player.CurrentSection);
            }
            while (IsGameInProgress);
        }
    }
}
