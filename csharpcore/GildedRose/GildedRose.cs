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
        foreach (var item in Items) { UpdateItem(item); }
    }

    private static void UpdateItem(Item item)
    {
        switch (item.Name)
        {
            case AGED_BRIE:
                UpdateBrie(item);
                break;
            case BACKSTAGE:
                UpdateBackStage(item);
                break;
            case SULFURAS:
                UpdateSulfuras(item);
                break;
            default:
                UpdateNormalItem(item);
                break;
        }
    }

    private static void UpdateBrie(Item item)
    {
        if (item.Name != AGED_BRIE &&
            item.Name != BACKSTAGE)
        {
            if (item.Quality > 0)
                if (item.Name != SULFURAS)
                    item.Quality = item.Quality - 1;
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

        if (item.Name != SULFURAS) item.SellIn = item.SellIn - 1;

        if (item.SellIn < 0)
        {
            if (item.Name != AGED_BRIE)
            {
                if (item.Name != BACKSTAGE)
                {
                    if (item.Quality > 0)
                        if (item.Name != SULFURAS)
                            item.Quality = item.Quality - 1;
                }
                else { item.Quality = item.Quality - item.Quality; }
            }
            else
            {
                if (item.Quality < 50) item.Quality = item.Quality + 1;
            }
        }
    }

    private static void UpdateBackStage(Item item)
    {
        if (item.Name != AGED_BRIE &&
            item.Name != BACKSTAGE)
        {
            if (item.Quality > 0)
                if (item.Name != SULFURAS)
                    item.Quality = item.Quality - 1;
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

        if (item.Name != SULFURAS) item.SellIn = item.SellIn - 1;

        if (item.SellIn < 0)
        {
            if (item.Name != AGED_BRIE)
            {
                if (item.Name != BACKSTAGE)
                {
                    if (item.Quality > 0)
                        if (item.Name != SULFURAS)
                            item.Quality = item.Quality - 1;
                }
                else { item.Quality = item.Quality - item.Quality; }
            }
            else
            {
                if (item.Quality < 50) item.Quality = item.Quality + 1;
            }
        }
    }

    private static void UpdateNormalItem(Item item)
    {
        if (item.Name != AGED_BRIE &&
            item.Name != BACKSTAGE)
        {
            if (item.Quality > 0)
                if (item.Name != SULFURAS)
                    item.Quality = item.Quality - 1;
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

        if (item.Name != SULFURAS) item.SellIn = item.SellIn - 1;

        if (item.SellIn < 0)
        {
            if (item.Name != AGED_BRIE)
            {
                if (item.Name != BACKSTAGE)
                {
                    if (item.Quality > 0)
                        if (item.Name != SULFURAS)
                            item.Quality = item.Quality - 1;
                }
                else { item.Quality = item.Quality - item.Quality; }
            }
            else
            {
                if (item.Quality < 50) item.Quality = item.Quality + 1;
            }
        }
    }

    private static void UpdateSulfuras(Item item)
    {
        if (item.Name != AGED_BRIE &&
            item.Name != BACKSTAGE)
        {
            if (item.Quality > 0)
                if (item.Name != SULFURAS)
                    item.Quality = item.Quality - 1;
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

        if (item.Name != SULFURAS) item.SellIn = item.SellIn - 1;

        if (item.SellIn < 0)
        {
            if (item.Name != AGED_BRIE)
            {
                if (item.Name != BACKSTAGE)
                {
                    if (item.Quality > 0)
                        if (item.Name != SULFURAS)
                            item.Quality = item.Quality - 1;
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