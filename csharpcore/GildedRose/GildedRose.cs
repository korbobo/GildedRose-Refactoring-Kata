using System.Collections.Generic;

namespace GildedRose;

public class GildedRose
{
    private const string AGED_BRIE = "Aged Brie";
    private const string BACKSTAGE = "Backstage passes to a TAFKAL80ETC concert";
    private const string SULFURAS = "Sulfuras, Hand of Ragnaros";
    public GildedRose(IList<Item> Items) { this.Items = Items; }
    public IList<Item> Items { get; }

    public void UpdateQuality()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            var item = Items[i];

            if (item.Name.Equals(SULFURAS)) { continue; }

            var qualityAdjustment = -1;
            var sellInAdjustment = -1;

            var qualityIncreases = item.Name.Equals(AGED_BRIE) || item.Name.Equals(BACKSTAGE);

            if (qualityIncreases)
            {
                qualityAdjustment = 1;

                if (item.Name == BACKSTAGE)
                {
                    qualityAdjustment = item.SellIn < 6 ? 3 :
                        item.SellIn < 11 ? 2 : qualityAdjustment;
                }
            }

            if (item.SellIn <= 0)
            {
                qualityAdjustment = -2;
                if (item.Name == BACKSTAGE) { qualityAdjustment = -item.Quality; }
            }

            UpdateItem(item, qualityAdjustment, sellInAdjustment);
        }
    }

    private void UpdateItem(Item item, int qualityAdjustment, int sellInAdjustment)
    {
        var newQuality = item.Quality + qualityAdjustment;
        newQuality = newQuality < 0 ? 0 : newQuality;
        newQuality = newQuality > 50 ? 50 : newQuality;

        item.Quality = newQuality;
        item.SellIn += sellInAdjustment;
    }
}