namespace BeerAdventure.Inventory
{
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Size Size { get; set; }

        public Item(string name, string description, Size weight)
        {
            Name = name;
            Description = description;
            Size = weight;
        }
    }
}
