namespace BeerAdventure.Display
{
    public class MenuItem
    {
        public string Description { get; set; }
        public Action Consequence { get; set; }

        public MenuItem(string description, Action consequence)
        {
            Description = description;
            Consequence = consequence;
        }
    }
}
