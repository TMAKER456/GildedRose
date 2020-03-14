namespace GildedRose.App.Items
{
    using Common;

    /// <summary>
    /// Sulfuras Item
    /// </summary>
    /// <remarks>Never has to be sold or decreases in quality.</remarks>
    [ItemName(nameof(Sulfuras))]
    internal sealed class Sulfuras : ItemBase
    {
        public Sulfuras(int sellIn, int quality) : base(sellIn, quality)
        { }

        /// <summary>
        /// Advances one day for this item.
        /// However this item does not have to be sold, so <see cref="ItemBase.SellIn"/> does not decrease for this item.
        /// </summary>
        public override void AdvanceDay() { }

        protected override int GetNextDaysQuality() => Quality;
    }
}
