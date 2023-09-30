using BeerAdventure.Character;
using BeerAdventure.Managers;
using BeerAdventure.Sections;

namespace BeerAdventure.Display
{
    public static class Beautifier
    {
        private const ConsoleColor _defaultForegroundColor = ConsoleColor.White;
        private const ConsoleColor _defaultInputColor = ConsoleColor.Magenta;
        private const ConsoleColor _defaultTitleColor = ConsoleColor.DarkYellow;
        private const ConsoleColor _defaultSuccessColor = ConsoleColor.Green;
        private const ConsoleColor _defaultFailureColor = ConsoleColor.Red;

        private const string _defaultBulletMenuPrompt = "What would you like to choose?: ";

        /// <summary>
        /// Displays the starting menu of the Beer Adventure game!
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public static void DisplayTitle()
            => BeautifierUtility.DisplayTitle();

        public static void Display<T>(T displayable)
        {
            if (displayable is BulletMenu menu)
                DisplayBulletMenu(menu);

            if (displayable is Section section)
                DisplaySection(section);

            if (displayable is Choice choice)
                DisplayChoice(choice);

            if (displayable is Connection connection)
                DisplayConnection(connection);
        }

        private static void DisplayBulletMenu(BulletMenu menu)
        {
            for (int i = 0; i < menu.MenuItems.Count; i++)
                Console.WriteLine(i + 1 + ": " + menu.MenuItems[i].Description);

            Console.WriteLine();
            int menuChoice = BeautifierUtility.PromptUser(_defaultBulletMenuPrompt, 1, menu.MenuItems.Count) - 1;

            menu.MenuItems[menuChoice].Consequence.Invoke();
        }

        private static void DisplaySection(Section section)
        {
            Console.WriteLine(section.Name);
            Console.WriteLine(section.Description);
            Console.WriteLine();

            BulletMenu sectionMenu = new();
            foreach (Choice choice in section.Choices)
                sectionMenu.MenuItems.Add(new(choice.Description, () => choice.Choose()));
                // DisplayChoice(choice);

            foreach (Connection connection in section.Connections)
                if (connection.IsVisible())
                    sectionMenu.MenuItems.Add(new(connection.Target.Name, () => connection.Choose()));

            Display(sectionMenu);

            // TODO: Place this somewhere else!
            Display(Player.CurrentSection);
        }

        private static void DisplayConnection(Connection connection)
        {
            Console.WriteLine(connection.Target.Name);
        }

        private static void DisplayChoice(Choice choice)
        {
            Console.WriteLine(choice.Description);
        }

        public static class BeautifierUtility
        {
            public static void DisplayTitle()
            {
                string title =
                    " ▄▄▄▄   ▓█████ ▓█████  ██▀███      ▄▄▄      ▓█████▄  ██▒   █▓▓█████  ███▄    █ ▄▄▄█████▓ █    ██  ██▀███  ▓█████ " +
                    "▓█████▄ ▓█   ▀ ▓█   ▀ ▓██ ▒ ██▒   ▒████▄    ▒██▀ ██▌▓██░   █▒▓█   ▀  ██ ▀█   █ ▓  ██▒ ▓▒ ██  ▓██▒▓██ ▒ ██▒▓█   ▀ " +
                    "▒██▒ ▄██▒███   ▒███   ▓██ ░▄█ ▒   ▒██  ▀█▄  ░██   █▌ ▓██  █▒░▒███   ▓██  ▀█ ██▒▒ ▓██░ ▒░▓██  ▒██░▓██ ░▄█ ▒▒███   " +
                    "▒██░█▀  ▒▓█  ▄ ▒▓█  ▄ ▒██▀▀█▄     ░██▄▄▄▄██ ░▓█▄   ▌  ▒██ █░░▒▓█  ▄ ▓██▒  ▐▌██▒░ ▓██▓ ░ ▓▓█  ░██░▒██▀▀█▄  ▒▓█  ▄ " +
                    "░▓█  ▀█▓░▒████▒░▒████▒░██▓ ▒██▒    ▓█   ▓██▒░▒████▓    ▒▀█░  ░▒████▒▒██░   ▓██░  ▒██▒ ░ ▒▒█████▓ ░██▓ ▒██▒░▒████▒" +
                    "░▒▓███▀▒░░ ▒░ ░░░ ▒░ ░░ ▒▓ ░▒▓░    ▒▒   ▓▒█░ ▒▒▓  ▒    ░ ▐░  ░░ ▒░ ░░ ▒░   ▒ ▒   ▒ ░░   ░▒▓▒ ▒ ▒ ░ ▒▓ ░▒▓░░░ ▒░ ░" +
                    "▒░▒   ░  ░ ░  ░ ░ ░  ░  ░▒ ░ ▒░     ▒   ▒▒ ░ ░ ▒  ▒    ░ ░░   ░ ░  ░░ ░░   ░ ▒░    ░    ░░▒░ ░ ░   ░▒ ░ ▒░ ░ ░  ░" +
                    " ░    ░    ░      ░     ░░   ░      ░   ▒    ░ ░  ░      ░░     ░      ░   ░ ░   ░       ░░░ ░ ░   ░░   ░    ░   " +
                    " ░         ░  ░   ░  ░   ░              ░  ░   ░          ░     ░  ░         ░             ░        ░        ░  ░" +
                    "     ░                                      ░           ░                                                        ";

                Console.ForegroundColor = _defaultTitleColor;
                Console.WriteLine(title);
                Console.ForegroundColor = _defaultForegroundColor;
            }

            /// <summary>
            /// Prompts the user, and returns their input.
            /// </summary>
            /// <param name="prompt">The message displayed to the user.</param>
            /// <returns>The response from the user. If faulty input was detected, an empty <see cref="string"/> is returned instead.</returns>
            public static string PromptUser(string prompt)
            {
                Console.Write(prompt);
                Console.ForegroundColor = _defaultInputColor;
                string? input = Console.ReadLine();
                Console.ForegroundColor = _defaultForegroundColor;

                if (input != null)
                    return input;
                else
                    return string.Empty;
            }

            /// <summary>
            /// Prompts the user and attempts to parse the response to an int within the range between <paramref name="minValue"/> and <paramref name="maxValue"/>.
            /// </summary>
            /// <param name="prompt">The prompt message displayed to the user.</param>
            /// <param name="minValue">The minimum value the response can be parsed to.</param>
            /// <param name="maxValue">The maximum value the response can be parsed to.</param>
            /// <returns>The response in the form of an <see cref="int"/>.</returns>
            public static int PromptUser(string prompt, int minValue, int maxValue)
            {
                string input = PromptUser(prompt);

                if (int.TryParse(input, out int inputNumber))
                    if (inputNumber >= minValue && inputNumber <= maxValue)
                        return inputNumber;
                
                throw new ArgumentException("That number is not within the permitted range of " + minValue + " - " + maxValue);
            }
        }
    }
}
