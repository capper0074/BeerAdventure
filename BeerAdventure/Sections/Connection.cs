using BeerAdventure.Managers;
using State = BeerAdventure.Managers.GameStateManager.State;

namespace BeerAdventure.Sections
{
    public class Connection
    {
        public Section Target { get; set; }
        public List<Prerequisite> Prerequisites { get; set; } = new();

        public List<Prerequisite> CheckConnection()
        {
            List<Prerequisite> unfufilledPreriquisites  = new();

            foreach (Prerequisite prerequisite in Prerequisites)
                if (GameStateManager.GetState(prerequisite.State) != prerequisite.RequiredValue)
                    unfufilledPreriquisites.Add(prerequisite);

            return unfufilledPreriquisites;
        }
    }
}
