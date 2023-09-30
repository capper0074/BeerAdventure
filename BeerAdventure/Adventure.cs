﻿using BeerAdventure.Character;
using BeerAdventure.Display;
using BeerAdventure.Managers;
using BeerAdventure.Sections;
using State = BeerAdventure.Managers.GameStateManager.State;

namespace BeerAdventure
{
    public class Adventure
    {
        public bool isInitialized = false;

        public void Initialize()
        {
            if (isInitialized)
                return;

#if DEBUG
            Console.WriteLine(nameof(Adventure) + " has been initialized!");
#endif

            isInitialized = true;
        }

        public void Start()
        {
            Section debugSection1 = new()
            {
                Name = "Debug section 1.",
                Description = "You find yourself amongst a lot of binary data... You're in the middle of a debug section!"
            };

            #region Debug Choices
            Choice debugSectionChoice1 = new()
            {
                Description = "Debug choice 1",
                SuccesfulConsequnce = () => GameStateManager.SetState(State.DebugState1, true),
                FailedConsequnce = () => { } // No failed consequence.
            };

            Choice debugSectionChoice2 = new()
            {
                Description = "Debug choice 2",
                SuccesfulConsequnce = () => GameStateManager.SetState(State.DebugState2, true),
                FailedConsequnce = () => { } // No failed consequence.
            };

            Prerequisite debugSectionChoice2Prerequisite1 = new()
            {
                State = State.DebugState1,
                RequiredValue = true
            };

            debugSectionChoice2.Prerequisites.Add(debugSectionChoice2Prerequisite1);

            Choice debugSectionChoice3 = new()
            {
                Description = "Debug choice 3",
                SuccesfulConsequnce = () => GameStateManager.SetState(State.DebugState3, true),
                FailedConsequnce = () => { } // No failed consequence.
            };

            Prerequisite debugSectionChoice3Prerequisite1 = new()
            {
                State = State.DebugState1,
                RequiredValue = true
            };

            Prerequisite debugSectionChoice3Prerequisite2 = new()
            {
                State = State.DebugState2,
                RequiredValue = true
            };

            debugSectionChoice3.Prerequisites.Add(debugSectionChoice3Prerequisite1);
            debugSectionChoice3.Prerequisites.Add(debugSectionChoice3Prerequisite2);

            debugSection1.Choices.Add(debugSectionChoice1);
            debugSection1.Choices.Add(debugSectionChoice2);
            debugSection1.Choices.Add(debugSectionChoice3);

            Section debugSection2 = new()
            {
                Name = "Debug section 2.",
                Description = "You seem to have moved further into the debug sections..."
            };
            #endregion

            #region Debug Connections
            Connection debugSection1Connection1 = new()
            {
                Target = debugSection2
            };

            debugSection1.Connections.Add(debugSection1Connection1);

            Connection debugSection2Connection1 = new()
            {
                Target = debugSection1
            };

            debugSection2.Connections.Add(debugSection2Connection1);
            #endregion

            Beautifier.Display(debugSection1);
        }
    }
}
