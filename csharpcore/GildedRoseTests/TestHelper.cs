using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class TestHelper
{
    internal static GildedRose CreateAndUpdateQuality(string itemName, int currentSellIn, int currentQuality)
    {
        var items = new List<Item>()
        {
            new()
            {
                Name = itemName,
                SellIn = currentSellIn,
                Quality = currentQuality
            }
        };

        var inn = new GildedRose(items);
        inn.UpdateQuality();

        return inn;
    }
}