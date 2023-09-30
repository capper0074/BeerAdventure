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