using System.Collections.Generic;
using System.Linq;
using GildedRoseKata;
using Xunit;

namespace GildedRoseTests;

public class GuildedRoseTests
{
    [Theory]
    [InlineData(10, 10, 9, 11)]
    public void Brie(int currentSellIn, int currentQuality, int expectedSellIn, int expectedQuality)
    {
        var items = new List<Item>()
        {
            new()
            {
                Name = "Aged Brie",
                Quality = currentQuality,
                SellIn = currentSellIn
            }
        };

        var inn = new GildedRose(items);
        inn.UpdateQuality();

        Assert.Equal(expectedSellIn, inn.Items.First().SellIn);
        Assert.Equal(expectedQuality, inn.Items.First().Quality);
    }
}