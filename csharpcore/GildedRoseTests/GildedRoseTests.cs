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
    [InlineData(10, 10, 9, 9)]
    public void NormalProduct(int currentSellIn, int currentQuality, int expectedSellIn, int expectedQuality)
    {
        var inn = TestHelper.CreateAndUpdateQuality("Normal Product", currentSellIn, currentQuality);

        Assert.Equal(expectedSellIn, inn.Items.First().SellIn);
        Assert.Equal(expectedQuality, inn.Items.First().Quality);
    }
}