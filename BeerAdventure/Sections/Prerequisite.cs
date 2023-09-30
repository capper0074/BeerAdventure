using BeerAdventure.Managers;
using State = BeerAdventure.Managers.GameStateManager.State;

namespace BeerAdventure.Sections
{
    public class Prerequisite
    {
        public State State { get; set; }
        public bool RequiredValue { get; set; }

        public string? FailureMessage;
        public string? SuccessMessage;

        public Prerequisite(State state, bool requiredValue)
        {
            State = state; 
            RequiredValue = requiredValue;
        }

        public bool Evaluate(out string? message)
        {
            if (GameStateManager.GetState(State) == RequiredValue)
            {
                message = SuccessMessage;
                return true;
            }

            message = FailureMessage;
            return false;
        }
    }
}
