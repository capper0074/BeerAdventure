using BeerAdventure.Sections;

namespace BeerAdventure.Character
{
    public static class Player
    {
        public static string Name { get; set; } = string.Empty;
        public static Section CurrentSection { get; set; } = new();
    }
}
