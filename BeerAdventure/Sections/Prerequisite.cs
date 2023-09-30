using State = BeerAdventure.Managers.GameStateManager.State;

namespace BeerAdventure.Sections
{
    public struct Prerequisite
    {
        public State State { get; set; }
        public bool RequiredValue { get; set; }

        public string? FailMessage;
        public string? SuccessMessage;
    }
}
