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

            var baseQualityAdjustment = -1;
            var baseSellInAdjustment = -1;

            if (item.Name != AGED_BRIE &&
                item.Name != BACKSTAGE)
            {
                if (item.Quality > 0) item.Quality = item.Quality - 1;
            }
            else
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;

                    if (item.Name == BACKSTAGE)
                    {
                        if (item.SellIn < 11)
                            if (item.Quality < 50)
                                item.Quality = item.Quality + 1;

                        if (item.SellIn < 6)
                            if (item.Quality < 50)
                                item.Quality = item.Quality + 1;
                    }
                }
            }

            item.SellIn = item.SellIn - 1;

            if (item.SellIn < 0)
            {
                if (item.Name != AGED_BRIE)
                {
                    if (item.Name != BACKSTAGE)
                    {
                        if (item.Quality > 0) item.Quality = item.Quality - 1;
                    }
                    else { item.Quality = item.Quality - item.Quality; }
                }
                else
                {
                    if (item.Quality < 50) item.Quality = item.Quality + 1;
                }
            }
        }
    }

    private void UpdateItem(Item item, int quantityAdjustment, int sellInAdjustment)
    {
        item.Quality += quantityAdjustment;
        item.SellIn += sellInAdjustment;
    }
}