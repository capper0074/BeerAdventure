using BeerAdventure.Sections;
using BeerAdventure.Inventory;
using State = BeerAdventure.Managers.GameStateManager.State;
using DisplayType = BeerAdventure.Display.Beautifier.DisplayType;
using BeerAdventure.Display;

namespace BeerAdventure.Managers
{
    public static class SectionManager
    {
        public enum SectionName
        {
            Home,
            Garden,
            Market
        }

        private static Dictionary<SectionName, Section> Sections { get; set; } = new();

        private const string HomeHeader = "  _    _                         \r\n | |  | |                        \r\n | |__| |  ___   _ __ ___    ___ \r\n |  __  | / _ \\ | '_ ` _ \\  / _ \\\r\n | |  | || (_) || | | | | ||  __/\r\n |_|  |_| \\___/ |_| |_| |_| \\___|\r\n                                 \r\n                                 ";
        private const string GardenHeader = "   _____                  _              \r\n  / ____|                | |             \r\n | |  __   __ _  _ __  __| |  ___  _ __  \r\n | | |_ | / _` || '__|/ _` | / _ \\| '_ \\ \r\n | |__| || (_| || |  | (_| ||  __/| | | |\r\n  \\_____| \\__,_||_|   \\__,_| \\___||_| |_|\r\n                                         \r\n                                         ";
        private const string MarketHeader = "  __  __               _          _   \r\n |  \\/  |             | |        | |  \r\n | \\  / |  __ _  _ __ | | __ ___ | |_ \r\n | |\\/| | / _` || '__|| |/ // _ \\| __|\r\n | |  | || (_| || |   |   <|  __/| |_ \r\n |_|  |_| \\__,_||_|   |_|\\_\\\\___| \\__|\r\n                                      \r\n                                      ";
        private const string CobblerHeader = "   _____        _      _      _             \r\n  / ____|      | |    | |    | |            \r\n | |      ___  | |__  | |__  | |  ___  _ __ \r\n | |     / _ \\ | '_ \\ | '_ \\ | | / _ \\| '__|\r\n | |____| (_) || |_) || |_) || ||  __/| |   \r\n  \\_____|\\___/ |_.__/ |_.__/ |_| \\___||_|   \r\n                                            \r\n                                            ";
        private const string BlacksmithHeader = "  ____   _               _                     _  _    _     \r\n |  _ \\ | |             | |                   (_)| |  | |    \r\n | |_) || |  __ _   ___ | | __ ___  _ __ ___   _ | |_ | |__  \r\n |  _ < | | / _` | / __|| |/ // __|| '_ ` _ \\ | || __|| '_ \\ \r\n | |_) || || (_| || (__ |   < \\__ \\| | | | | || || |_ | | | |\r\n |____/ |_| \\__,_| \\___||_|\\_\\|___/|_| |_| |_||_| \\__||_| |_|\r\n                                                             \r\n                                                             ";
        private const string SwampHeader = "   _____                                  \r\n  / ____|                                 \r\n | (___ __      __ __ _  _ __ ___   _ __  \r\n  \\___ \\\\ \\ /\\ / // _` || '_ ` _ \\ | '_ \\ \r\n  ____) |\\ V  V /| (_| || | | | | || |_) |\r\n |_____/  \\_/\\_/  \\__,_||_| |_| |_|| .__/ \r\n                                   | |    \r\n                                   |_|    ";
        private const string WitchsHouseHeader = " __          __ _        _    _     _       _    _                          \r\n \\ \\        / /(_)      | |  | |   ( )     | |  | |                         \r\n  \\ \\  /\\  / /  _   ___ | |_ | |__ |/ ___  | |__| |  ___   _   _  ___   ___ \r\n   \\ \\/  \\/ /  | | / __|| __|| '_ \\  / __| |  __  | / _ \\ | | | |/ __| / _ \\\r\n    \\  /\\  /   | || (__ | |_ | | | | \\__ \\ | |  | || (_) || |_| |\\__ \\|  __/\r\n     \\/  \\/    |_| \\___| \\__||_| |_| |___/ |_|  |_| \\___/  \\__,_||___/ \\___|\r\n                                                                            \r\n                                                                            ";
        private const string SecretPassageHeader = "   _____                         _     _____                                     \r\n  / ____|                       | |   |  __ \\                                    \r\n | (___    ___   ___  _ __  ___ | |_  | |__) |__ _  ___  ___   __ _   __ _   ___ \r\n  \\___ \\  / _ \\ / __|| '__|/ _ \\| __| |  ___// _` |/ __|/ __| / _` | / _` | / _ \\\r\n  ____) ||  __/| (__ | |  |  __/| |_  | |   | (_| |\\__ \\\\__ \\| (_| || (_| ||  __/\r\n |_____/  \\___| \\___||_|   \\___| \\__| |_|    \\__,_||___/|___/ \\__,_| \\__, | \\___|\r\n                                                                      __/ |      \r\n                                                                     |___/       ";
        private const string CityBarHeader = "   _____  _  _            ____               \r\n  / ____|(_)| |          |  _ \\              \r\n | |      _ | |_  _   _  | |_) |  __ _  _ __ \r\n | |     | || __|| | | | |  _ <  / _` || '__|\r\n | |____ | || |_ | |_| | | |_) || (_| || |   \r\n  \\_____||_| \\__| \\__, | |____/  \\__,_||_|   \r\n                   __/ |                     \r\n                  |___/                      ";

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
                "You stumble into your wretched, filth-ridden house, the stench reminding you of a brew \n" +
                "gone terribly wrong. Amid the squalor, you can't help but dream of the sweet, frothy taste of beer, \n" +
                "a momentary escape from the chaos of your tiny world.\n" +
                " \n" +
                "You decide to...");

            Choice homeSectionSearchHouse = new(
                "... search the house for anything that could be of help.",
                new()
                {
                    new(State.HasSearchedHome, false)
                },
                () =>
                {
                    Item coin = new("Rusty coin", "It smells a bit funny, you wonder where it has been...", Size.Small);

                    Beautifier.DisplayString("You decide to search your home in the hopes that you find something useful.\n" +
                        "Only you know what you might find beneath the piles of stone you have been hoarding...\n");

                    Beautifier.BeautifierUtility.PromptContinue();

                    Beautifier.Countdown();
                    Beautifier.DisplayString("A glint catches your eye!\n");
                    
                    Beautifier.BeautifierUtility.PromptContinue();

                    Beautifier.Countdown();
                    Beautifier.DisplayString($"You find a rusty coin!\n", DisplayType.Success);

                    InventoryManager.SmallItems.Add(coin);

                    Beautifier.BeautifierUtility.PromptContinue();

                    Beautifier.Countdown();
                    Beautifier.DisplayString($"And then another coin, not rusty this time!\n", DisplayType.Success);

                    InventoryManager.Coins++;

                    GameStateManager.SetState(State.HasSearchedHome, true);
                },
                () => !GameStateManager.GetState(State.HasSearchedHome));

            homeSection.Choices.Add(homeSectionSearchHouse);
            // ----- HOME -----

            // ----- GARDEN -----
            Section gardenSection = new(
                GardenHeader,
                "Your dwarf's garden is a thorn in your side, filled with sticks, leaves, and other nuisances \n" +
                "that irritate you to no end. It's a constant battle to keep it in check, and you often grumble \n" +
                "about how much you despise tending to it.\n" +
                "\n" +
                "From here you decide that you ...");

            Choice gardenSectionCheckBushes = new(
                "... approach the bushes and check if there's anything of interest.",
                new()
                {
                    new(State.HasReceivedSecretBushStashHint, true)
                },
                () =>
                {
                    Beautifier.DisplayString(
                        "\"Leaves and bushes... Why do they even exist?\" you mutter to yourself. You can't eat them, you can't\n" +
                        "build with them, heck, you can't even use them to blow stuff up! Pathetic!\n");

                    Beautifier.BeautifierUtility.PromptContinue();
                    Beautifier.DisplayString("Ah, maybe this is the bush the stash hint mentioned?\n");

                    Beautifier.BeautifierUtility.PromptContinue();

                    Beautifier.DisplayString("You begin digging, as fast as your tiny limbs can manage!\n");
                    Beautifier.Countdown();
                    Beautifier.Countdown();
                    Beautifier.Countdown();
                    
                    Beautifier.DisplayString("After digging for what seems to be an eternity with the small hairy hardened arms of yours\n" +
                        "you finally hit something solid that isn't just another rock!\n");
                    Beautifier.BeautifierUtility.PromptContinue();

                    Beautifier.DisplayString("You find a stash of *exactly* 69 coins! Nice!\n", DisplayType.Success);

                    GameStateManager.SetState(State.HasFoundSecretBushStash, true);

                    // TODO: Deprecated.
                    InventoryManager.Coins += 69;

                    GameStateManager.SetState(State.HasLotsMoney, true);
                },
                () =>
                {
                    Beautifier.DisplayString(
                        "Leaves and bushes... Why do they even exist? You can't eat them, you can't build with them, heck, you\n" +
                        "can't even use them to blow stuff up. It is nothing more than trash! But hey, maybe theres something\n" +
                        "under them that you can use? The good stuff is always below!\n");

                    Beautifier.BeautifierUtility.PromptContinue();

                    Beautifier.Countdown();
                    Beautifier.DisplayString("As you expected, nothing here is worth your time.\n");
                },
                () => !GameStateManager.GetState(State.HasFoundSecretBushStash));

            gardenSection.Choices.Add(gardenSectionCheckBushes);
            // ----- GARDEN -----

            homeSection.Connections.Add(new("... head outside.", gardenSection));
            gardenSection.Connections.Add(new("... hurry back to your own garden, away from all the sticks and leaves!", homeSection));

            Section marketSection = new(
                MarketHeader,
                "You have arrived at the market, at the center of the village. Dwarves, old and young, fill the space\n" +
                "on the streets while chatter and laughter fills the air. The smell of smoke from the blacksmith reaches\n" +
                "you, but before you get too comfortable, the smell of piss from the cobblers leather tanning operation\n" +
                "makes its way up your nostrils. Darn!\n" +
                "\n" +
                "From here you choose that you ...");

            gardenSection.Connections.Add(new("... head out and approach the market.", marketSection));
            marketSection.Connections.Add(new("... head back to the sticks and smelly leaves.", gardenSection));

            Section cityBarSection = new(
                CityBarHeader,
                "A cozy hideaway in the heart of the city, the City Bar welcomes all, big and small. \n" +
                "Dimly lit with a hearty atmosphere, it's where dwarf dreams are brewed in barrels and laughter flows \n" +
                "like a river of ale.\n" +
                "\n" +
                "You make up your mind, and decide to ...\n");

            marketSection.Connections.Add(new("... head to the glorius City Bar!", cityBarSection));
            cityBarSection.Connections.Add(new("... head to the pissy smelly market, with a frown on your tiny face...", marketSection));

            Choice cityBarSectionEnterCityBar = new(
                "... enter the bar, and get a round of glorius beer!",
                new()
                {
                    new(State.HasShoesOn, true)
                },
                () =>
                {
                    // TODO: cHANGE THIS 
                    Beautifier.DisplayString("Hooray, you win boi!\n", DisplayType.Success);
                },
                () =>
                {
                    Beautifier.DisplayString("You approach the grand tavern, but the bouncer mistakes you for a kid dwarf. \n" +
                        "\"Sorry, little one, no ale for you!\" they chuckle. Frustration brews within you, thinking, \n" +
                        "\"I may be small, but I've got a thirst as big as any dwarf!\" Perhaps if I could get taller they \n" +
                        "would let me in?\n");
                });

            cityBarSection.Choices.Add(cityBarSectionEnterCityBar);

            Section cobblerSection = new(
                CobblerHeader,
                "A bloody cramped cobbler's dive, stinking of piss and grumbling dwarves, with leather boots \n" +
                "piled like a shite heap, and a foul-mouthed dwarf cobbler who'd rather cuss than cobble.\n" +
                "\n" +
                "Despite your better judgement, you ...");

            Choice cobblerSectionBuyShoes = new(
                "... make a bid on the tall shoes the cobbler has for sale.",
                new List<Prerequisite>()
                {
                    new Prerequisite(State.HasLotsMoney, true)
                },
                () =>
                {
                    Beautifier.DisplayString("The stubborn dwarf cobbler eyes you with a glare that could curdle ale, \n" +
                        "but begrudgingly mutters, \"Fine, if ya must.\" He fetches a pair of battered leather boots \n" +
                        "from the shite heap, grumbling, \"These'll cost ya, and they'll smell worse than this place.\"\n");

                    Beautifier.BeautifierUtility.PromptContinue();

                    Beautifier.DisplayString("You now have a pair of leather boots with high heels!\n", DisplayType.Success);

                    GameStateManager.SetState(State.HasShoesOn, true);
                },
                () =>
                {
                    Beautifier.DisplayString("The crotchety dwarf cobbler scowls at your request, shaking his head vehemently.\n"); 
                    Beautifier.DisplayString("\"You'd ruin 'em in a blink, ya wee idiot! Get out before I toss ya out!\"\n", DisplayType.Failure);
                    Beautifier.DisplayString("You deduce from his reaction that you need a lot of money.\n", DisplayType.Emphasis);
                },
                () => !GameStateManager.GetState(State.HasShoesOn));

            cobblerSection.Choices.Add(cobblerSectionBuyShoes);

            marketSection.Connections.Add(new("... embrace the smell of piss, and approach the pissy cobbler.", cobblerSection));
            cobblerSection.Connections.Add(new("... hurry outside to the *somewhat* clean air.", marketSection));

            Section swampSection = new(
                SwampHeader,
                "Navigating this bloody swamp is a nightmare, with flies thicker than a troll's hide buzzing about. \n" +
                "The air reeks like a goblin's armpit, and you trudge through muck that'd make even a dwarf curse \n" +
                "the day they were born.\n" +
                "\n" +
                "You decide to...");

            swampSection.Connections.Add(new("... go to drier land, and head back to your garden.", gardenSection));
            gardenSection.Connections.Add(new("... go to the smelly puddle of piss and poop. (Swamp)", swampSection));

            Choice swampSectionTalkToWitch = new(
                "... hollar at the crooked backed bitch bog.",
                () =>
                {
                    if (!GameStateManager.GetState(State.HasReceivedSecretBushStashHint))
                    {
                        Beautifier.DisplayString("Your shouts startle the crooked-backed witchybitch in the murky swamp. \n" +
                            "She cackles, revealing a toothless grin, and whispers:\n");
                        Beautifier.DisplayString("\"Hidden treasure lies in yonder bush. \n" +
                            "Hush now, and follow the glimmer, little kush.\"\n", DisplayType.Emphasis);

                        GameStateManager.SetState(State.HasReceivedSecretBushStashHint, true);
                    }
                    else
                    {
                        Beautifier.DisplayString("As you approach the crooked-backed witch in the gloomy swamp, she merely scoffs, \n" +
                            "\"Aye, we've already had our chat, dimwit dwarf. Nothin' more to spill from these old lips of mine.\"\n" +
                            "She shoos you away dismissively, leaving you to ponder her cryptic words.\n");
                    }
                });

            swampSection.Choices.Add(swampSectionTalkToWitch);

            // TODO: Figure out what this is?
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

