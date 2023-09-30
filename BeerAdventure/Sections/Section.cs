namespace BeerAdventure.Sections
{
    public class Section
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Choice> Choices { get; set; } = new();
        public List<Connection> Connections { get; set; } = new();

        public Section(string name, string description, List<Choice> choices, List<Connection> connections)
        {
            Name = name;
            Description = description;
            Choices = choices;
            Connections = connections;
        }

        public Section(string name, string description, List<Choice> choices)
            : this(name, description, choices, new()) { }

        public Section(string name, string description, List<Connection> connections)
            : this(name, description, new(), connections) { }

        public Section(string name, string description)
            : this(name, description, new(), new()) { }
    }
}
