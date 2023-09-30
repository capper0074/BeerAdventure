using BeerAdventure.Display;
using BeerAdventure.Managers;

namespace BeerAdventure.Sections
{
    public class Connection
    {
        public string Description { get; set; }
        public Section Target { get; set; }
        public List<Prerequisite> Prerequisites { get; set; }
        public Func<bool> IsVisible { get; set; }

        public Connection(string description, Section target, List<Prerequisite> prerequisites, Func<bool> isVisible)
        {
            Description = description;
            Target = target;
            Prerequisites = prerequisites;
            IsVisible = isVisible;
        }

        public Connection(string description, Section target, List<Prerequisite> prerequisites)
            : this(description, target, prerequisites, () => true) { }

        public Connection(string description, Section target)
            : this(description, target, new()) { }

        public void Choose()
        {
            bool allPrerequisistesFulfilled = true;

            // Check if all prerequisites are fulfilled.
            foreach (Prerequisite prerequisite in Prerequisites)
                // Is the value of the State not the required value?
                if (!prerequisite.Evaluate(out string? message))
                {
                    Beautifier.Display(message);
                    allPrerequisistesFulfilled = false;
                    break;
                }

            // All prerequisites are fulfilled!
            if (allPrerequisistesFulfilled == true)
                MovementManager.MovePlayer(Target);
        }
    }
}
