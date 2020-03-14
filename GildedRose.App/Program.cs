using System;

namespace GildedRose.App
{
    using Inventory;

    public static class Program
    {
        public static void Main(string[] args)
        {
            InventoryManager inventoryManager = new InventoryManager();

            if (args?.Length > 0)
            {
                TryProcessInput(inventoryManager, string.Join(' ', args));
            }
            else
            {
                while (true)
                {
                    Console.WriteLine("Enter item:");
                    string inputData = Console.ReadLine();

                    if (inputData.Equals("Exit", StringComparison.OrdinalIgnoreCase)) return;

                    TryProcessInput(inventoryManager, inputData);

                    Console.WriteLine();
                }
            }
        }

        private static void TryProcessInput(InventoryManager inventoryManager, string inputData)
        {
            try
            {
                string outputData = inventoryManager.ProcessItem(inputData);
                Console.WriteLine(outputData);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
}
