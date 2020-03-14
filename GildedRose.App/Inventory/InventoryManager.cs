namespace GildedRose.App.Inventory
{
    using Items.Common;

    public class InventoryManager
    {
        private readonly ItemFactory itemFactory = new ItemFactory();

        public string ProcessItem(string inputData)
        {
            IItem item = itemFactory.CreateItem(inputData);

            item.AdvanceDay();

            return item.ToString();
        }
    }
}
