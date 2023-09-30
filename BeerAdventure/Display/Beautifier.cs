using BeerAdventure.Sections;

namespace BeerAdventure.Display
{
    public static class Beautifier
    {
        /// <summary>
        /// Displays the starting menu of the Beer Adventure game!
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public static void ShowStartMenu()
            => throw new NotImplementedException();

        public static void Display<T>(T displayable)
        {
            if (displayable is Section section)
                ShowSection(section);

            if (displayable is Choice choice)
                ShowChoice(choice);

            if (displayable is Connection connection)
                ShowConnection(connection);
        }

        private static void ShowSection(Section section)
            => throw new NotImplementedException();

        private static void ShowConnection(Connection connection)
            => throw new NotImplementedException();

        private static void ShowChoice(Choice choice)
            => throw new NotImplementedException();
    }
}
