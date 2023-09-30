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

            if (allPrerequisistesFulfilled)
                Console.WriteLine("Møller, look over here, this is where the PlayerMovementManager should set the currentSection to the Target of this Connection, plz bby ❤️");
            else
                Console.WriteLine("Møller, this is where the connection determined it was not okay to pass through this connection. Please stop the player or sumting bby ❤️");
        }
    }
}
