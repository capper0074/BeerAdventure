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

        public static void DisplayTitle()
            => BeautifierUtility.DisplayTitle();

        public static void Display<T>(T displayable)
        {
            if (displayable is string displayableString)
            {
                ConsoleColor consoleColor = Console.ForegroundColor;
                Console.ForegroundColor = _defaultForegroundColor;
                Console.WriteLine(displayableString);
                Console.ForegroundColor = consoleColor;
            }

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
            Console.CursorVisible = false;

            int targetedMenuItem = 0;
            (int startLeft, int startTop) = Console.GetCursorPosition();

            for (int i = 0; i < menu.MenuItems.Count; i++)
            {
                if (i == targetedMenuItem)
                {
                    Console.ForegroundColor = _defaultSuccessColor;
                    Console.WriteLine("   " + menu.MenuItems[i].Description + "   ");
                    Console.ForegroundColor = _defaultForegroundColor;
                }
                else
                    Console.WriteLine("   " + menu.MenuItems[i].Description + "   ");
            }

            (int endLeft, int endTop) = Console.GetCursorPosition();

            ConsoleKey pressedKey;

            do
            {
                Console.ForegroundColor = _defaultInputColor;
                Console.SetCursorPosition(startLeft + 1, startTop + targetedMenuItem);
                Console.Write('[');
                Console.SetCursorPosition(startLeft + 4 + menu.MenuItems[targetedMenuItem].Description.Length, startTop + targetedMenuItem);
                Console.Write(']');
                Console.ForegroundColor = _defaultForegroundColor;

                pressedKey = Console.ReadKey(true).Key;

                if (pressedKey == ConsoleKey.DownArrow)
                    targetedMenuItem++;

                if (pressedKey == ConsoleKey.UpArrow)
                    targetedMenuItem--;

                if (targetedMenuItem < 0)
                    targetedMenuItem = menu.MenuItems.Count - 1;

                if (targetedMenuItem > menu.MenuItems.Count - 1)
                    targetedMenuItem = 0;

                Console.SetCursorPosition(startLeft, startTop);

                for (int i = 0; i < menu.MenuItems.Count; i++)
                {
                    if (i == targetedMenuItem)
                    {
                        Console.ForegroundColor = _defaultSuccessColor;
                        Console.WriteLine("   " + menu.MenuItems[i].Description + "   ");
                        Console.ForegroundColor = _defaultForegroundColor;
                    }
                    else
                        Console.WriteLine("   " + menu.MenuItems[i].Description + "   ");
                }
            }
            while (!(pressedKey == ConsoleKey.Enter || pressedKey == ConsoleKey.Spacebar));

            // int menuChoice = BeautifierUtility.PromptUser(_defaultBulletMenuPrompt, 1, menu.MenuItems.Count) - 1;

            Console.SetCursorPosition(endLeft, endTop);

            Console.WriteLine(); // For spacing.

            menu.MenuItems[targetedMenuItem].Consequence();
        }

        private static void DisplaySection(Section section)
        {
            Console.Clear();

            Console.ForegroundColor = _defaultTitleColor;
            Console.WriteLine(section.Name);
            Console.ForegroundColor = _defaultForegroundColor;

            Console.WriteLine(section.Description);
            Console.WriteLine();

            BulletMenu sectionMenu = new();
            foreach (Choice choice in section.Choices)
                if (choice.IsVisibleWhen())
                    sectionMenu.MenuItems.Add(new(choice.Description, () => choice.Choose()));

            foreach (Connection connection in section.Connections)
                if (connection.IsVisible())
                    sectionMenu.MenuItems.Add(new(connection.Description, () => connection.Choose()));

            Display(sectionMenu);

            BeautifierUtility.PromptContinue();
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
                #region DON'T TOUCH THIS PLEASE
                int preferredWidth = Console.WindowWidth / 2 - (73 / 2);
                string padding = string.Empty;

                for (int i = 0; i < preferredWidth; i++)
                    padding += " ";

                string title = 
                    padding + @" ____                               _                 _                  " + "\n" +
                    padding + @"|  _ \                     /\      | |               | |                 " + "\n" +
                    padding + @"| |_) | ___  ___ _ __     /  \   __| |_   _____ _ __ | |_ _   _ _ __ ___ " + "\n" +
                    padding + @"|  _ < / _ \/ _ \ '__|   / /\ \ / _` \ \ / / _ \ '_ \| __| | | | '__/ _ \" + "\n" +
                    padding + @"| |_) |  __/  __/ |     / ____ \ (_| |\ V /  __/ | | | |_| |_| | | |  __/" + "\n" +
                    padding + @"|____/ \___|\___|_|    /_/    \_\__,_| \_/ \___|_| |_|\__|\__,_|_|  \___|" + "\n";

                Console.ForegroundColor = _defaultTitleColor;
                Console.WriteLine(title);
                Console.ForegroundColor = _defaultForegroundColor;
                #endregion
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
                do
                {
                    string input = PromptUser(prompt);

                    if (int.TryParse(input, out int inputNumber))
                        if (inputNumber >= minValue && inputNumber <= maxValue)
                            return inputNumber;

                    Console.ForegroundColor = _defaultFailureColor;
                    Console.WriteLine("Hmm, that doesn't appear to be a valid choice right now...");
                    Console.ForegroundColor = _defaultForegroundColor;
                } 
                while (true);

                // throw new ArgumentException("That number is not within the permitted range of " + minValue + " - " + maxValue);
            }

            public static void PromptContinue()
            {
                Console.ForegroundColor = _defaultInputColor;
                Console.Write("[Continue...]");
                Console.ForegroundColor = _defaultForegroundColor;

                ConsoleKeyInfo keyPressed;

                do
                {
                    keyPressed = Console.ReadKey(true);
                } 
                while (!(keyPressed.Key == ConsoleKey.Enter || keyPressed.Key == ConsoleKey.Spacebar));
            }
        }
    }
}
