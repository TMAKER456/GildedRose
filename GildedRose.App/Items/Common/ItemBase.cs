using System;
using System.Linq;

namespace GildedRose.App.Items.Common
{
    internal abstract class ItemBase : IItem
    {
        protected const int MaxQuality = 50;
        protected const int MinQuality = 0;

        public int SellIn { get; private set; }

        public int Quality { get; private set; }

        protected bool SellByDatePassed => SellIn < 0;

        /// <summary>
        /// For use with items whose quality degrades twice as quickly when their sell by date has passed.
        /// Returns 2 when <see cref="SellByDatePassed"/> is true, otherwise 1.
        /// </summary>
        protected int SellByDateFactor => SellByDatePassed ? 2 : 1;

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

        /// <summary>
        /// Outputs this item in its current state in the expected format ({ItemName} {SellIn} {Quality}).
        /// </summary>
        /// <returns></returns>
        public string ToOutputString() 
            => $"{GetType().GetCustomAttributes(typeof(ItemNameAttribute), false).Cast<ItemNameAttribute>().SingleOrDefault()?.ItemName.ToString()} {SellIn} {Quality}";
    }
}
