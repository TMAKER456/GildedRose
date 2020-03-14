namespace GildedRose.App.Items
{
    using Common;

    /// <summary>
    /// Normal Item
    /// </summary>
    /// <remarks>Decreases in Quality by 1 per day.</remarks>
    internal class Normal : ItemBase
    {
        protected const int NormalItemAdjustmentValue = -1;

        public Normal(int sellIn, int quality) : base(sellIn, quality)
        { }

        protected override int GetNextDaysQuality() => Quality + NormalItemAdjustmentValue;
    }
}
