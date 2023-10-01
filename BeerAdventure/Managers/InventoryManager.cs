using BeerAdventure.Inventory;

namespace BeerAdventure.Managers
{
    public static class InventoryManager
    {
        public static bool HasAnyItems { get => SmallItems.Count > 0 || MediumItems.Count > 0 || LargeItems.Count > 0 || Coins > 0; }

        public static List<Item> SmallItems = new();
        public static List<Item> MediumItems = new();
        public static List<Item> LargeItems = new();

        public static int Coins { get; set; } = 0;
    }
}
