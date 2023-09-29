using BeerAdventure.Sections;
using BeerAdventure.Managers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace BeerAdventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameStateManager.Initialize();

            // Start game...
            Section oldWomanShack = new()
            {
                Name = "Old womans shack.",
                Description = "You are facing a old woman, she wants bread.",
                Choices = new()
                {
                    new Choice()
                    {
                        Description = "Deliver bread.",
                        Prerequisites = new()
                        {
                            (GameStateManager.State.HasDeliveredBread, false)
                        },
                        SuccesfulConsequnce = () =>
                        {
                            GameStateManager.SetState(GameStateManager.State.HasDeliveredBread, true);
                        },
                        IsVisible = !GameStateManager.GetState(GameStateManager.State.HasDeliveredBread) // Only show if the player has bread in the Inventory.
                    }
                },
                Connections = new() { }
            };

            Section oldMan = new()
            {
                Name = "Old man shack",
                Description = "You are facing an old man. He has a lot of money.",
                Choices = new()
                {
                    new Choice()
                    {
                        Description = "Borrow money from old lanky-ass man!",
                        Prerequisites = new()
                        {
                            (GameStateManager.State.HasDeliveredBread, true)
                        },
                        SuccesfulConsequnce = () =>
                        {
                            Console.WriteLine("I luv u braddar! Take all my money!");
                        },
                        FailedConsequnce = () => 
                        {
                            Console.WriteLine("You are ugly and you smell.");
                        },
                        IsVisible = true
                    }
                }
            };

            oldWomanShack.Connections.Add(oldMan);
            oldMan.Connections.Add(oldWomanShack);

            oldMan.Choices[0].Choose();
            DisplaySection(oldWomanShack);

            oldWomanShack.Choices[0].Choose();
            DisplaySection(oldMan);

            oldMan.Choices[0].Choose();
        }

        public static void DisplaySection(Section section)
        {


            // Display section:
            Console.WriteLine(section.Name);
            Console.WriteLine(section.Description);

            foreach (Choice choice in section.Choices)
                Console.WriteLine(choice.Description);

            foreach (Section connection in section.Connections)
                Console.WriteLine(connection.Name);

            Console.ReadLine();
        }
    }
}