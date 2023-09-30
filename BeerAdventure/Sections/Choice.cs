using BeerAdventure.Display;

namespace BeerAdventure.Sections
{
    public class Choice
    {
        public string Description { get; set; }
        public List<Prerequisite> Prerequisites { get; set; }
        public Action SuccesfulConsequnce { get; set; }
        public Action FailedConsequnce { get; set; }
        public Func<bool> IsVisibleWhen { get; set; }

        public Choice(string description, List<Prerequisite> prerequisites, Action succesfulConsequence, Action failedConsequence, Func<bool> isVisibleWhen)
        {
            Description = description;
            Prerequisites = prerequisites;
            SuccesfulConsequnce = succesfulConsequence;
            FailedConsequnce = failedConsequence;
            IsVisibleWhen = isVisibleWhen;
        }

        public Choice(string description, List<Prerequisite> prerequisites, Action succesfulConsequence, Action failedConsequence) 
            : this(description, prerequisites, succesfulConsequence, failedConsequence, () => true) { }

        public Choice(string description, List<Prerequisite> prerequisites, Action succesfulConsequence)
            : this(description, prerequisites, succesfulConsequence, () => { }) { }

        public Choice(string description, Action succesfulConsequence)
            : this(description, new(), succesfulConsequence) { }

        /// <summary>
        /// Acts out all the behavior that should happen when this choice is selected by the player.
        /// </summary>
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
                SuccesfulConsequnce();
            else
                FailedConsequnce();
        }
    }
}
