using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.UnitTest
{
    [TestClass]
    public class AfterSellByTests : TestBase
    {
        [TestMethod]
        public void ConjuredAfterSellBy1() => TestAndAssert("Conjured -4 5", "Conjured -5 1");
        
        [TestMethod]
        public void ConjuredAfterSellBy2() => TestAndAssert("Conjured -4 0", "Conjured -5 0");
        
        [TestMethod]
        public void ConjuredAfterSellBy3() => TestAndAssert("Conjured -4 4", "Conjured -5 0");


        
        [TestMethod]
        public void AgedBrieAfterSellBy1() => TestAndAssert("Aged Brie -4 5", "Aged Brie -5 7");
        
        [TestMethod]
        public void AgedBrieAfterSellBy2() => TestAndAssert("Aged Brie -4 0", "Aged Brie -5 2");

        
        [TestMethod]
        public void NormalAfterSellBy1() => TestAndAssert("Normal Item -4 5", "Normal Item -5 3");
        
        [TestMethod]
        public void NormalAfterSellBy2() => TestAndAssert("Normal Item -4 2", "Normal Item -5 0");
        
        [TestMethod]
        public void NormalAfterSellBy3() => TestAndAssert("Normal Item -4 0", "Normal Item -5 0");
    }
}
