namespace GildedRose.App.Items
{
    using Common;

    /// <summary>
    /// Invalid Item
    /// </summary>
    [ItemName("Invalid Item")]
    internal class Invalid : IItem
    {
        int IItem.Quality => default;

        int IItem.SellIn => default;

        /// <summary>
        /// Non functional.
        /// </summary>
        void IItem.AdvanceDay() { }

        public string ToOutputString() => "NO SUCH ITEM";
    }
}
