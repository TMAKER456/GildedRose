using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GildedRose.UnitTest
{
    [TestClass]
    public class ErrorTests : TestBase
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SellInTooLow() => TestAndAssert("Normal Item -9999999 1", string.Empty);

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SellInTooHigh() => TestAndAssert("Normal Item 9999999 1", string.Empty);


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void QualityTooLow() => TestAndAssert("Normal Item 1 -1", string.Empty);

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void QualityTooHigh() => TestAndAssert("Normal Item 1 9999999", string.Empty);

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void InvalidFormat1() => TestAndAssert("Normal Item 1-1", string.Empty);

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void InvalidFormat2() => TestAndAssert("Normal Item1 1", string.Empty);

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void InvalidFormat3() => TestAndAssert("Normal Item ", string.Empty);
    }
}
