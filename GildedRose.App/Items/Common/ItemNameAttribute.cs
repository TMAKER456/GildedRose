using System;

namespace GildedRose.App.Items.Common
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    internal class ItemNameAttribute : Attribute
    {
        public string ItemName { get; }

        public ItemNameAttribute(string itemName)
        {
            ItemName = itemName;
        }
    }
}
