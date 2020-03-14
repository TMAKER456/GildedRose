namespace GildedRose.App.Items
{
    using Common;

    /// <summary>
    /// Invalid Item
    /// </summary>
    internal class Invalid : IItem
    {
        int IItem.Quality => default;

        int IItem.SellIn => default;

        /// <summary>
        /// Non functional.
        /// </summary>
        void IItem.AdvanceDay() { }

        public override string ToString() => "NO SUCH ITEM";
    }
}
