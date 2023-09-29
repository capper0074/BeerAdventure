namespace BeerAdventure.Sections
{
    public class Choice
    {
        public string Description { get; set; } = string.Empty;
        public List<bool> Prerequisites { get; set; } = new();
        public Action SuccesfulConsequnce { get; set; } = () => { throw new NotImplementedException(); };
        public Action FailedConsequnce { get; set; } = () => { throw new NotImplementedException(); };
        public bool IsVisible { get; set; }

        public void Choose()
        {
            bool allPrerequisistesFulfilled = true;
            foreach (bool prerequisites in Prerequisites)
                if (!prerequisites)
                    allPrerequisistesFulfilled = false;
            
            if (allPrerequisistesFulfilled)
                SuccesfulConsequnce.Invoke();
            else 
                FailedConsequnce.Invoke();

        }
    }
}
