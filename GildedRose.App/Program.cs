using System;

namespace GildedRose.App
{
    using Inventory;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter item:");
            string inputData = Console.ReadLine();

            InventoryManager inventoryManager = new InventoryManager();

            string outputData = inventoryManager.ProcessItem(inputData);

            Console.WriteLine(outputData);

            Console.ReadLine();
        }
    }
}
