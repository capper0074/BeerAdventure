//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//using BeerAdventure.Sections;


//namespace BeerAdventure.Managers
//{
//    public class SectionBuilder
//    {
//        Section oldWomanShack = new Section()
//        {
//            Name = "Old womans shack.",
//            Description = "You are facing a old woman, she wants bread.",
//            Choices = new()
//            {
//                new Choice()
//                {
//                    Description = "Deliver bread.",
//                    Prerequisites = new()
//                    {
//                        !GameStateManager.HasDeliveredBread
//                    },
//                    SuccesfulConsequnce = () =>
//                    {
//                        GameStateManager.HasDeliveredBread = true;
//                    },
//                    IsVisible = !GameStateManager.HasDeliveredBread // Only show if the player has bread in the Inventory.
//                }
//            },
//            Connections = new()
//            {
//            }
//        };


//        public SectionBuilder()
//        {
//            Section oldMan = new()
//            {
//                Name = "Old man shack",
//                Description = "You are facing an old man. He has a lot of money.",
//                Choices = new()
//                {
//                    new Choice()
//                    {
//                        Description = "Borrow money from old lanky-ass man!",
//                        Prerequisites = new()
//                        {
//                            GameStateManager.HasDeliveredBread
//                        },
//                        SuccesfulConsequnce = () =>
//                        {
//                            Console.WriteLine("I luv u braddar! Take all my money!");
//                        },
//                        FailedConsequnce = () =>
//                        {
//                            Console.WriteLine("You are ugly and you smell.");
//                        },
//                        IsVisible = true
//                    }
//                }
//            };
//        }
//    }
//}
