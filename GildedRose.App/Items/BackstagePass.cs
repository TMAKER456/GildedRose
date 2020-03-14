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
    internal sealed class BackstagePass : ItemBase
    {
        public BackstagePass(int sellIn, int quality) : base(sellIn, quality)
        { }

        //protected override int GetNextDaysQuality()
        //{
        //    if (SellIn <= 0)
        //    {
        //        return 0;
        //    }
        //    else if (SellIn <= 5)
        //    {
        //        return Quality +3;
        //    }
        //    else if (SellIn <= 10)
        //    {
        //        return Quality +2;
        //    }
        //    else
        //    {
        //        return Quality +1;
        //    }
        //}

        protected override int GetNextDaysQuality()
            => SellIn switch
            {
                int i when i <= 0 => Quality + 3,
                int i when i <= 5 => Quality + 2,
                int i when i <= 10 => Quality + 1,
                _ => Quality + 1
            };
    }
}
