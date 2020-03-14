using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.UnitTest
{
    [TestClass]
    public class QualityRangeTests : TestBase
    {
        [TestMethod]
        public void QualityOverLimit() => TestAndAssert("Conjured 2 60", "Conjured 1 50");

        [TestMethod]
        public void QualityBelowLimit() => TestAndAssert("Conjured 2 1", "Conjured 1 0");
    }
}
