namespace BeerAdventure.Managers
{
    public static class GameStateManager
    {
        public enum State
        {
            DebugState1,
            DebugState2,
            DebugState3,
            HasDeliveredBread,
            AnotherFalsePrerequisite
        }

        public static Dictionary<State, bool> States = new();

        public static bool IsInitialized = false;

        public static void Initialize()
        {
            if (IsInitialized)
                return;

            States.Add(State.DebugState1, false);
            States.Add(State.DebugState2, false);
            States.Add(State.DebugState3, false);
            States.Add(State.HasDeliveredBread, false);
            States.Add(State.AnotherFalsePrerequisite, false);

            IsInitialized = true;
        }

        public static bool GetState(State state)
        {
            if (!States.ContainsKey(state))
                throw new ArgumentException("No matching key found in dictionary. Key: " + state.ToString());

            return States[state];
        }

        public static void SetState(State state, bool value)
        {
            if (!States.ContainsKey(state))
                throw new ArgumentException("No matching key found in dictionary. Key: " + state.ToString());

            States[state] = value;
        }
    }
}
