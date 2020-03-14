using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.UnitTest
{
    using App.Inventory;

    public class TestBase
    {
        private readonly InventoryManager inventoryProcessor = new InventoryManager();

        protected void TestAndAssert(string input, string expectedOutput) => Assert.AreEqual(expectedOutput, inventoryProcessor.ProcessItem(input));

    }
}
