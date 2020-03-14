using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.UnitTest
{
    [TestClass]
    public class ExampleTests : TestBase
    {
        [TestMethod]
        public void AgedBrie() => TestAndAssert("Aged Brie 1 1", "Aged Brie 0 2");

        [TestMethod]
        public void BackstagePasses1() => TestAndAssert("Backstage passes -1 2", "Backstage passes -2 0");

        [TestMethod]
        public void BackstagePasses2() => TestAndAssert("Backstage passes 9 2", "Backstage passes 8 4");

        [TestMethod]
        public void Sulfuras() => TestAndAssert("Sulfuras 2 2", "Sulfuras 2 2");

        [TestMethod]
        public void NormalItem1() => TestAndAssert("Normal Item -1 55", "Normal Item -2 50");

        [TestMethod]
        public void NormalItem2() => TestAndAssert("Normal Item 2 2", "Normal Item 1 1");

        [TestMethod]
        public void InvalidItem() => TestAndAssert("INVALID ITEM 2 2", "NO SUCH ITEM");

        [TestMethod]
        public void Conjured1() => TestAndAssert("Conjured 2 2", "Conjured 1 0");

        [TestMethod]
        public void Conjured2() => TestAndAssert("Conjured -1 5", "Conjured -2 1");
    }
}
