using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerAdventure.Sections;
using BeerAdventure.Stuff;
using State = BeerAdventure.Managers.GameStateManager.State;

namespace BeerAdventure.Managers
{
    public class SectionBuilder
    {
        public SectionBuilder()
        {
            List<Item> items = new();
            {
                //Make items
            }

            //Add items to WitchInventory
            foreach(Item i in items)
                if (i.Size == Size.Small)
                {
                    WitchInventory.SmallItems.Add(i);
                }
            foreach (Item i in items)
                if (i.Size == Size.Medium)
                {
                    WitchInventory.MediumItems.Add(i);
                }
            foreach (Item i in items)
                if (i.Size == Size.Large)
                {
                    WitchInventory.LargeItems.Add(i);
                }

            Section theMarketSection = new()
            {
                Name = "The Market",
                Description = "This place smells like a rich mix of smelly feet and happy faces.",
            };
            //----------------------------------------------------------------------------------------------------------
            Section theWitchHouseSection = new()
            {
                Name = "The Witch House",
                Description = "A witch reside within this mystic house, who knows what kind of things has happened within these walls.",

                Choices = new()
                {
                    new Choice()
                    {
                        Description = "Talk to the witch. . .",
                        Prerequisites = new()
                        {
                            new()
                            {
                                State = State.HasNotTalkedToWitch,
                                RequiredValue = true
                            }
                        },
                        SuccesfulConsequnce = () =>
                        {
                            Console.WriteLine("Hello young dwarf, i could smell your stinky feet from a horseday away, anyways, welcome to my house, in which i sell potions and magical objects");
                            Thread.Sleep(1000);
                            Console.WriteLine($"What do you want?");

                            GameStateManager.SetState(State.HasNotTalkedToWitch, false);
                        },
                        IsVisible = GameStateManager.GetState(State.HasNotTalkedToWitch)
                    },
                                        
                    new Choice()
                    {
                        Description = "\"I want to see your inventory\"",
                        SuccesfulConsequnce = () =>
                        {
                            Console.WriteLine("Sure have a look. . .");
                            Thread.Sleep(1000);
                            //Show witch inventory
                        },
                        IsVisible = !GameStateManager.GetState(State.HasNotTalkedToWitch)
                    }
                },
            };
            //----------------------------------------------------------------------------------------------------------
            Section theShallowMarshSection = new()
            {
                Name = "The Shallow Marsh",
                Description = "Nothing but pests and insects survives more than a week in these parts outside the village.",
            };
            //----------------------------------------------------------------------------------------------------------
            Section homeSection = new()
            {
                Name = "Home",
                Description = "You are home, in your little shack the size of a large horse, it smells like char and rum.",
                Choices = new()
                {
                    new Choice()
                    {
                        Description = "Search house",
                        Prerequisites = new()
                        {
                            new()
                            {
                                State = State.HasNotSearchedHouse,
                                RequiredValue = true
                            }
                        },
                        SuccesfulConsequnce = () =>
                        {
                            Item coin = new("Rusty coin", "It smells a bit funny, you wonder where it has been. . .", Size.Small);

                            Console.WriteLine("You search the house. . .");
                            Thread.Sleep(1000);
                            Console.WriteLine($"You found a coin!");


                            Inventory.Inventory.SmallItems.Add( coin );

                            GameStateManager.SetState(State.HasNotSearchedHouse, false);
                        },
                        IsVisible = GameStateManager.GetState(State.HasNotSearchedHouse)
                    }
                },
            };
            //----------------------------------------------------------------------------------------------------------
            //Make connections here
            //Check miro for what connection prerecuisites needs to be made, for an example, the shallow marsh cannot be entered if you are not wearing thick leather boots
        }
    }
}

