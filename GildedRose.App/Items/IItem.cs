namespace GildedRose.App.Items
{
    internal interface IItem
    {
        int SellIn { get; }

        int Quality { get; }

        void AdvanceDay();

        string ToString();
    }
}
