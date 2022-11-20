using System.Linq;
using Xunit;

namespace GildedRoseTests;

public class GildedRoseTests
{
    [Theory]
    [InlineData(10, 10, 9, 11)]
    public void Brie(int currentSellIn, int currentQuality, int expectedSellIn, int expectedQuality)
    {
        var inn = TestHelper.CreateAndUpdateQuality("Aged Brie", currentSellIn, currentQuality);

        Assert.Equal(expectedSellIn, inn.Items.First().SellIn);
        Assert.Equal(expectedQuality, inn.Items.First().Quality);
    }
    
    [Theory]
    [InlineData(10, 10, 9, 9)] // At the end of each day our system lowers both values for every item
    [InlineData(10, 0, 9, 0)] // The Quality of an item is never negative
    [InlineData(0, 2, -1, 0)] // Once the sell by date has passed, Quality degrades twice as fast
    public void NormalProduct(int currentSellIn, int currentQuality, int expectedSellIn, int expectedQuality)
    {
        var inn = TestHelper.CreateAndUpdateQuality("Normal Product", currentSellIn, currentQuality);

        Assert.Equal(expectedSellIn, inn.Items.First().SellIn);
        Assert.Equal(expectedQuality, inn.Items.First().Quality);
    }
    
    [Theory]
    [InlineData(10, 80, 10, 80)]
    public void Sulfuras(int currentSellIn, int currentQuality, int expectedSellIn, int expectedQuality)
    {
        var inn = TestHelper.CreateAndUpdateQuality("Sulfuras, Hand of Ragnaros", currentSellIn, currentQuality);

        Assert.Equal(expectedSellIn, inn.Items.First().SellIn);
        Assert.Equal(expectedQuality, inn.Items.First().Quality);
    }
    
    [Theory]
    [InlineData(20, 10, 19, 11)]
    public void Backstage(int currentSellIn, int currentQuality, int expectedSellIn, int expectedQuality)
    {
        var inn = TestHelper.CreateAndUpdateQuality("Backstage passes to a TAFKAL80ETC concert", currentSellIn, currentQuality);

        Assert.Equal(expectedSellIn, inn.Items.First().SellIn);
        Assert.Equal(expectedQuality, inn.Items.First().Quality);
    }
}