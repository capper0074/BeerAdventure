using BeerAdventure.Managers;

namespace BeerAdventure.Sections
{
    public class Choice
    {
        public string Description { get; set; } = string.Empty;
        public List<Prerequisite> Prerequisites { get; set; } = new();
        public Action SuccesfulConsequnce { get; set; } = () => { throw new NotImplementedException(); };
        public Action FailedConsequnce { get; set; } = () => { throw new NotImplementedException(); };
        public bool IsVisible { get; set; }

        public void Choose()
        {
            bool allPrerequisistesFulfilled = true;
            foreach (Prerequisite prerequisite in Prerequisites)
                if (GameStateManager.GetState(prerequisite.State) != prerequisite.RequiredValue)
                    allPrerequisistesFulfilled = false;
            
            if (allPrerequisistesFulfilled == true)
                SuccesfulConsequnce.Invoke();
            else 
                FailedConsequnce.Invoke();

        }
    }
}
