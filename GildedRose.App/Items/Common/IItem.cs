namespace GildedRose.App.Items.Common
{
    internal interface IItem
    {
        int SellIn { get; }

        int Quality { get; }

        void AdvanceDay();

        string ToOutputString();
    }
}
