using BeerAdventure.Character;
using BeerAdventure.Managers;
using State = BeerAdventure.Managers.GameStateManager.State;

namespace BeerAdventure.Sections
{
    public class Connection
    {
        public Section Target { get; set; }
        public List<Prerequisite> Prerequisites { get; set; } = new();

        public void Choose()
        {
            bool allPrerequisistesFulfilled = true;
            foreach (Prerequisite prerequisite in Prerequisites)
                if (GameStateManager.GetState(prerequisite.State) != prerequisite.RequiredValue)
                    allPrerequisistesFulfilled = false;

            if (allPrerequisistesFulfilled == true)
                Player.CurrentSection = Target;
        }
    }
}
