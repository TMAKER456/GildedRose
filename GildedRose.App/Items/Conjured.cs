namespace GildedRose.App.Items
{
    using Common;

    /// <summary>
    /// Conjured item
    /// </summary>
    /// <remarks>Degrades in Quality twice as fast as normal items</remarks>
    [ItemName(nameof(Conjured))]
    internal sealed class Conjured : Normal
    {
        public Conjured(int sellIn, int quality) : base(sellIn, quality)
        { }

        protected override int GetNextDaysQuality() => Quality + (2 * NormalItemAdjustmentValue * SellByDateFactor);
    }
}
