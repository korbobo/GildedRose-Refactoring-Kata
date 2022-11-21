﻿using System.Collections.Generic;

namespace GildedRose;

public class GildedRose
{
    private const string AGED_BRIE = "Aged Brie";
    private const string BACKSTAGE = "Backstage passes to a TAFKAL80ETC concert";
    private const string SULFURAS = "SULFURAS, Hand of Ragnaros";
    public GildedRose(IList<Item> Items) { this.Items = Items; }

    public IList<Item> Items { get; }

    public void UpdateQuality()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            if (Items[i].Name != AGED_BRIE &&
                Items[i].Name != BACKSTAGE)
            {
                if (Items[i].Quality > 0)
                    if (Items[i].Name != SULFURAS)
                        Items[i].Quality = Items[i].Quality - 1;
            }
            else
            {
                if (Items[i].Quality < 50)
                {
                    Items[i].Quality = Items[i].Quality + 1;

                    if (Items[i].Name == BACKSTAGE)
                    {
                        if (Items[i].SellIn < 11)
                            if (Items[i].Quality < 50)
                                Items[i].Quality = Items[i].Quality + 1;

                        if (Items[i].SellIn < 6)
                            if (Items[i].Quality < 50)
                                Items[i].Quality = Items[i].Quality + 1;
                    }
                }
            }

            if (Items[i].Name != SULFURAS) Items[i].SellIn = Items[i].SellIn - 1;

            if (Items[i].SellIn < 0)
            {
                if (Items[i].Name != AGED_BRIE)
                {
                    if (Items[i].Name != BACKSTAGE)
                    {
                        if (Items[i].Quality > 0)
                            if (Items[i].Name != SULFURAS)
                                Items[i].Quality = Items[i].Quality - 1;
                    }
                    else { Items[i].Quality = Items[i].Quality - Items[i].Quality; }
                }
                else
                {
                    if (Items[i].Quality < 50) Items[i].Quality = Items[i].Quality + 1;
                }
            }
        }
    }
}