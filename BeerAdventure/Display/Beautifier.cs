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
                ShowSection(section);

            if (displayable is Choice choice)
                ShowChoice(choice);

            if (displayable is Connection connection)
                ShowConnection(connection);
        }

        private static void DisplayBulletMenu(BulletMenu menu)
        {
            for (int i = 0; i < menu.MenuItems.Count; i++)
                Console.WriteLine(i + 1 + ": " + menu.MenuItems[i].Description);

            Console.WriteLine();
            int menuChoice = BeautifierUtility.PromptUser(_defaultBulletMenuPrompt, 1, menu.MenuItems.Count) - 1;

            menu.MenuItems[menuChoice].Consequence.Invoke();
        }

        private static void ShowSection(Section section)
            => throw new NotImplementedException();

        private static void ShowConnection(Connection connection)
            => throw new NotImplementedException();

        private static void ShowChoice(Choice choice)
            => throw new NotImplementedException();

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
                    return inputNumber;
                else
                    return -1;
            }
        }
    }
}
