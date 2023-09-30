namespace BeerAdventure.Sections
{
    public class Section
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Choice> Choices { get; set; } = new();
        public List<Connection> Connections { get; set; } = new();
    }
}
