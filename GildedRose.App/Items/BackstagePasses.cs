namespace GildedRose.App.Items
{
    using Common;

    /// <summary>
    /// Backstage Pass item
    /// </summary>
    /// <remarks>
    /// Increases in Quality as its SellIn value approaches
    /// Its quality increases by 2 when there are 10 days or less and by 3 when
    /// there are 5 days or less but quality drops to 0 after the concert
    /// </remarks>
    [ItemName("Backstage passes")]
    internal sealed class BackstagePasses : ItemBase
    {
        public BackstagePasses(int sellIn, int quality) : base(sellIn, quality)
        { }

        protected override int GetNextDaysQuality()
            => SellIn switch
            {
                int i when i <= 0 => Quality - Quality,
                int i when i <= 5 => Quality + 1,
                int i when i <= 10 => Quality + 2,
                _ => Quality + 1
            };
    }
}
