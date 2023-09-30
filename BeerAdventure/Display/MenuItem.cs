namespace BeerAdventure.Display
{
    public class MenuItem
    {
        public string Description { get; set; } = string.Empty;

        public MenuItem(string description)
        {
            Description = description;
        }
    }
}
