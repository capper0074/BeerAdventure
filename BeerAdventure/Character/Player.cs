using BeerAdventure.Sections;

namespace BeerAdventure.Character
{
    public static class Player
    {
        public static string Name { get; set; } = string.Empty;
        // TODO: Add default section from sectionmanager here when done.
        public static Section CurrentSection { get; set; }
    }
}
