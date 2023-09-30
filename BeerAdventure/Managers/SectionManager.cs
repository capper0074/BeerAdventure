using BeerAdventure.Sections;
using BeerAdventure.Inventory;
using State = BeerAdventure.Managers.GameStateManager.State;

namespace BeerAdventure.Managers
{
    public static class SectionManager
    {
        public enum SectionName
        {
            Home,
            Garden
        }

        private static Dictionary<SectionName, Section> Sections { get; set; } = new();

        private const string HomeHeader = "  _    _                         \r\n | |  | |                        \r\n | |__| |  ___   _ __ ___    ___ \r\n |  __  | / _ \\ | '_ ` _ \\  / _ \\\r\n | |  | || (_) || | | | | ||  __/\r\n |_|  |_| \\___/ |_| |_| |_| \\___|\r\n                                 \r\n                                 ";
        private const string GardenHeader = "   _____                  _              \r\n  / ____|                | |             \r\n | |  __   __ _  _ __  __| |  ___  _ __  \r\n | | |_ | / _` || '__|/ _` | / _ \\| '_ \\ \r\n | |__| || (_| || |  | (_| ||  __/| | | |\r\n  \\_____| \\__,_||_|   \\__,_| \\___||_| |_|\r\n                                         \r\n                                         ";

        public static bool IsInitialized { get; private set; } = false;

        #region Old Initialization
        //    public SectionManager()
        //    {
        //        List<Item> items = new();
        //        {
        //            //Make items
        //        }

        //        //Add items to WitchInventory
        //        foreach(Item i in items)
        //            if (i.Size == Size.Small)
        //            {
        //                WitchInventory.SmallItems.Add(i);
        //            }
        //        foreach (Item i in items)
        //            if (i.Size == Size.Medium)
        //            {
        //                WitchInventory.MediumItems.Add(i);
        //            }
        //        foreach (Item i in items)
        //            if (i.Size == Size.Large)
        //            {
        //                WitchInventory.LargeItems.Add(i);
        //            }

        //        Section theMarketSection = new()
        //        {
        //            Name = "The Market",
        //            Description = "This place smells like a rich mix of smelly feet and happy faces.",
        //        };
        //        //----------------------------------------------------------------------------------------------------------
        //        Section theWitchHouseSection = new()
        //        {
        //            Name = "The Witch House",
        //            Description = "A witch reside within this mystic house, who knows what kind of things has happened within these walls.",

        //            Choices = new()
        //            {
        //                new Choice()
        //                {
        //                    Description = "Talk to the witch. . .",
        //                    Prerequisites = new()
        //                    {
        //                        new()
        //                        {
        //                            State = State.HasNotTalkedToWitch,
        //                            RequiredValue = true
        //                        }
        //                    },
        //                    SuccesfulConsequnce = () =>
        //                    {
        //                        Console.WriteLine("Hello young dwarf, i could smell your stinky feet from a horseday away, anyways, welcome to my house, in which i sell potions and magical objects");
        //                        Thread.Sleep(1000);
        //                        Console.WriteLine($"What do you want?");

        //                        GameStateManager.SetState(State.HasNotTalkedToWitch, false);
        //                    },
        //                    IsVisibleWhen = () => GameStateManager.GetState(State.HasNotTalkedToWitch)
        //                },

        //                new Choice()
        //                {
        //                    Description = "\"I want to see your inventory\"",
        //                    SuccesfulConsequnce = () =>
        //                    {
        //                        Console.WriteLine("Sure have a look. . .");
        //                        Thread.Sleep(1000);
        //                        //Show witch inventory
        //                    },
        //                    IsVisibleWhen = () => !GameStateManager.GetState(State.HasNotTalkedToWitch)
        //                }
        //            },
        //        };
        //        //----------------------------------------------------------------------------------------------------------
        //        Section theShallowMarshSection = new()
        //        {
        //            Name = "The Shallow Marsh",
        //            Description = "Nothing but pests and insects survives more than a week in these parts outside the village.",
        //        };
        //        //----------------------------------------------------------------------------------------------------------
        //        Section homeSection = new()
        //        {
        //            Name = "Home",
        //            Description = "You are home, in your little shack the size of a large horse, it smells like char and rum.",
        //            Choices = new()
        //            {
        //                new Choice()
        //                {
        //                    Description = "Search house",
        //                    Prerequisites = new()
        //                    {
        //                        new()
        //                        {
        //                            State = State.HasNotSearchedHouse,
        //                            RequiredValue = true
        //                        }
        //                    },
        //                    SuccesfulConsequnce = () =>
        //                    {
        //                        Item coin = new("Rusty coin", "It smells a bit funny, you wonder where it has been. . .", Size.Small);

        //                        Console.WriteLine("You search the house. . .");
        //                        Thread.Sleep(1000);
        //                        Console.WriteLine($"You found a coin!");


        //                        Inventory.Inventory.SmallItems.Add( coin );

        //                        GameStateManager.SetState(State.HasNotSearchedHouse, false);
        //                    },
        //                    IsVisibleWhen = () => GameStateManager.GetState(State.HasNotSearchedHouse)
        //                }
        //            },
        //        };
        //        //----------------------------------------------------------------------------------------------------------
        //        //Make connections here
        //        //Check miro for what connection prerecuisites needs to be made, for an example, the shallow marsh cannot be entered if you are not wearing thick leather boots
        //    }
        #endregion

        public static void Initialize()
        {
            if (IsInitialized)
                return;

            // ----- HOME -----
            Section homeSection = new(
                HomeHeader, 
                "You are home, in your little shack the size of a large horse, it smells like char and rum.\n" +
                "Everywhere you look clutter is what you see.\n" +
                "\n" +
                "You still don't know how you manage to get dressed in clean clothes (almost) every day.\n" +
                "\n" +
                "You decide to...");

            Choice searchHouse = new(
                "... search the house for anything that could be of help.",
                new()
                {
                    new(State.HasSearchedHome, false)
                },
                () =>
                {
                    Item coin = new("Rusty coin", "It smells a bit funny, you wonder where it has been...", Size.Small);

                    Console.WriteLine("You search the house...");
                    Thread.Sleep(1000);
                    Console.WriteLine($"You found a coin!");

                    InventoryManager.SmallItems.Add(coin);

                    GameStateManager.SetState(State.HasSearchedHome, true);
                },
                () => !GameStateManager.GetState(State.HasSearchedHome));

            homeSection.Choices.Add(searchHouse);
            // ----- HOME -----

            // ----- GARDEN -----
            Section gardenSection = new(
                GardenHeader,
                "You find yourself in the middle of your garden.\n" +
                "Considering that you is a dwarf, and you is now surrounded by greenery,\n" +
                "the hair on your body rises and a chill travels down your spine.\n" +
                "\n" +
                "From here you decide that you ...");

            // ----- GARDEN -----

            homeSection.Connections.Add(new("... head outside.", gardenSection));

            gardenSection.Connections.Add(new("... hurry back inside, away from all the sticks and leaves!", homeSection));

            Sections.Add(SectionName.Home, homeSection);
            Sections.Add(SectionName.Garden, gardenSection);

            IsInitialized = true;
        }

        public static Section GetSection(SectionName sectionName)
        {
            if (!IsInitialized)
                throw new InvalidOperationException("The section manager has not yet been initialized.");

            if (!Sections.ContainsKey(sectionName))
                throw new ArgumentException("No section associated to the provided section name.");

            return Sections[sectionName];
        }
    }
}

