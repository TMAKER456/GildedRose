namespace GildedRose.App.Items
{
    using Common;

    /// <summary>
    /// Aged Brie Item
    /// </summary>
    /// <remarks>Increases in Quality the older it gets.</remarks>
    [ItemName("Aged Brie")]
    internal sealed class AgedBrie : ItemBase
    {
        public AgedBrie(int sellIn, int quality) : base(sellIn, quality)
        { }

        protected override int GetNextDaysQuality() => Quality + (1 * SellByDateFactor);
    }
}
