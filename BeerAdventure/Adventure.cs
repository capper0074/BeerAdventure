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
    }
}
