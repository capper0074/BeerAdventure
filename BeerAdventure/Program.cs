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
            // Start game...
            



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