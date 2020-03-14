using System;

namespace GildedRose.App.Items.Common
{
    internal abstract class ItemBase : IItem
    {
        protected const int MaxQuality = 50;
        protected const int MinQuality = 0;

        public int SellIn { get; private set; }

        public int Quality { get; private set; }


        internal ItemBase(int sellIn, int quality)
        {
            SellIn = sellIn;
            Quality = quality;
        }

        /// <summary>
        /// Advances one day for this item.
        /// </summary>
        public virtual void AdvanceDay()
        {
            SetNextDaysQuality(GetNextDaysQuality());
            SellIn--;
        }

        /// <summary>
        /// Sets the next day's quality value and ensures that it does not exceed the boundaries of Quality.
        /// </summary>
        /// <param name="newQuality">The new quality value for the next day.</param>
        private void SetNextDaysQuality(int newQuality) => Quality = Math.Max(Math.Min(newQuality, MaxQuality), MinQuality);

        protected abstract int GetNextDaysQuality();
    }
}
