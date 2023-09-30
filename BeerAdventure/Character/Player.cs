using BeerAdventure.Sections;

namespace BeerAdventure.Character
{
    public class Player
    {
        public static string Name { get; set; } = string.Empty;
        public Section CurrentSection { get; set; } = new();

    }
}
