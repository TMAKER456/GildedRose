using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GildedRose.App.Items.Common
{
    internal class ItemFactory
    {
        private const int MaxSellInInput = 10000;
        private const int MaxQualityInput = 10000;
        private const int MinSellInInput = -10000;
        private const int MinQualityInput = 0;
        private const string FormatError = @"Input was not in the correct format. Expected: '{ItemName} {SellIn:int} {Quality:int}'";

        private delegate ItemBase ItemBaseCtor(int sellIn, int quality);

        private Lazy<Dictionary<string, ItemBaseCtor>> ItemConstructors { get; } = new Lazy<Dictionary<string, ItemBaseCtor>>(GenerateItemConstructorDictionary);

        internal IItem CreateItem(string itemData)
        {
            var (itemName, sellIn, quality) = ParseInputData(itemData);

            return CreateItem(itemName, sellIn, quality);
        }

        internal IItem CreateItem(string itemName, int sellIn, int quality)
        {
            // Assessment's instructions unclear as to whether the item name is case or whitespace sensitive.
            // Have assumed case insensitive, but inner whitespace required (spaces between words of item name are required).

            if (ItemConstructors.Value.TryGetValue(itemName.ToLower().Trim(), out var itemCtor))
            {
                return itemCtor(sellIn, quality);
            }
            else
            {
                return new Invalid();
            }
        }

        private (string itemName, int sellIn, int quality) ParseInputData(string inputData)
        {
            string[] inputParts = inputData.Split(' ');

            if (inputParts.Length < 3)
            {
                throw new FormatException(FormatError);
            }

            if (!int.TryParse(inputParts[^2], out int sellIn))
            {
                throw new FormatException(FormatError);
            }
            else if (sellIn > MaxSellInInput || sellIn < MinSellInInput)
            {
                throw new ArgumentOutOfRangeException($"SellIn must be between {MinSellInInput} and {MaxSellInInput}. Value entered: {sellIn}");
            }

            if (!int.TryParse(inputParts[^1], out int quality))
            {
                throw new FormatException(FormatError);
            }
            else if (quality > MaxQualityInput || quality < MinQualityInput)
            {
                throw new ArgumentOutOfRangeException($"Quality must be between {MinQualityInput} and {MaxQualityInput}. Value entered: {quality}");
            }

            string itemName = string.Join(' ', inputParts[0..^2]);

            return (itemName, sellIn, quality);
        }

        /// <summary>
        /// Scans this assembly for all items which inherit from ItemBase, reads the item name from its <see cref="ItemNameAttribute"/>,
        /// then generates constructor delegates for all items found and combines them into a dictionary
        /// so that the item name can be used to return a method which creates an instance of that item.
        /// </summary>
        /// <returns>
        /// A dictionary where the key is the item name, 
        /// and the value is a constructor method that creates an instance of the item.
        /// </returns>
        private static Dictionary<string, ItemBaseCtor> GenerateItemConstructorDictionary()
            => typeof(ItemBase).Assembly.GetTypes()
                .Where(t => t.IsClass && (t.BaseType == typeof(ItemBase) || GetParentTypes(t).Any(t => t == typeof(ItemBase))))
                .Select(t => (type: t, attributes: t.GetCustomAttributes(typeof(ItemNameAttribute), false).Cast<ItemNameAttribute>()))
                .Where(ta => ta.attributes.Any())
                .Select(ta => (ta.type, attribute: ta.attributes.Single()))
                .ToDictionary(ta => ta.attribute.ItemName.ToLower().Trim(), ta => CreateItemBaseCtor(ta.type));

        /// <summary>
        /// Generates a constructor function for the <paramref name="itemType"/>.
        /// </summary>
        /// <param name="itemType"></param>
        /// <returns></returns>
        private static ItemBaseCtor CreateItemBaseCtor(Type itemType)
        {
            var paramSellIn = Expression.Parameter(typeof(int), "sellIn");
            var paramQuality = Expression.Parameter(typeof(int), "quality");

            var ctorInfo = itemType.GetConstructor(new[] { typeof(int), typeof(int) });
            var lambda = Expression.Lambda<ItemBaseCtor>(Expression.New(ctorInfo, paramSellIn, paramQuality), paramSellIn, paramQuality);

            return lambda.Compile();
        }

        /// <summary>
        /// Returns all parent types in the type's inheritance chain.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static IEnumerable<Type> GetParentTypes(Type type)
        {
            Type currentBaseType = type.BaseType;
            while (currentBaseType is Type)
            {
                yield return currentBaseType;
                currentBaseType = currentBaseType.BaseType;
            }
        }
    }
}
