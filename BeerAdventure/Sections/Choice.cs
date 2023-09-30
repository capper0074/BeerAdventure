using BeerAdventure.Managers;

namespace BeerAdventure.Sections
{
    public class Choice
    {
        public string Description { get; set; } = string.Empty;
        public List<(GameStateManager.State, bool)> Prerequisites { get; set; } = new();
        public Action SuccesfulConsequnce { get; set; } = () => { throw new NotImplementedException(); };
        public Action FailedConsequnce { get; set; } = () => { throw new NotImplementedException(); };
        public bool IsVisible { get; set; }

        public void Choose()
        {
            bool allPrerequisistesFulfilled = true;
            foreach ((GameStateManager.State state, bool value) prerequisite in Prerequisites)
                if (GameStateManager.GetState(prerequisite.state) != prerequisite.value)
                    allPrerequisistesFulfilled = false;
            
            if (allPrerequisistesFulfilled == true)
                SuccesfulConsequnce.Invoke();
            else 
                FailedConsequnce.Invoke();

        }
    }
}
