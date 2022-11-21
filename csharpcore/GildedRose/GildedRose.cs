using System.Collections.Generic;

namespace GildedRose;

public class GildedRose
{
    private const string AGED_BRIE = "Aged Brie";
    private const string BACKSTAGE = "Backstage passes to a TAFKAL80ETC concert";
    private const string SULFURAS = "Sulfuras, Hand of Ragnaros";
    private const string CONJURED = "Conjured";
    public GildedRose(IList<Item> Items) { this.Items = Items; }
    public IList<Item> Items { get; }

    public void UpdateQuality()
    {
        foreach (var item in Items) Updateitem(item);
    }

    private void Updateitem(Item item)
    {
        var noChangesRequired = item.Name.Equals(SULFURAS);
        if (noChangesRequired) return;

        var qualityAdjustment = -1;
        var sellInAdjustment = -1;

        var isBackStage = item.Name.Equals(BACKSTAGE);
        var isConjured = item.Name.Equals(CONJURED);

        if (isConjured)
        {
            qualityAdjustment = -2;
        }
        
        var qualityIncreases = item.Name.Equals(AGED_BRIE) || item.Name.Equals(BACKSTAGE);
        if (qualityIncreases)
        {
            qualityAdjustment = 1;

            if (isBackStage)
                qualityAdjustment = item.SellIn < 6 ? 3 :
                    item.SellIn < 11 ? 2 : qualityAdjustment;
        }

        var isExpired = item.SellIn <= 0;
        if (isExpired)
        {
            qualityAdjustment = -2;
            if (isBackStage) qualityAdjustment = -item.Quality;
            if (isConjured) qualityAdjustment = -4;
        }

        ApplyFormula(item, qualityAdjustment, sellInAdjustment);
    }

    private void ApplyFormula(Item item, int qualityAdjustment, int sellInAdjustment)
    {
        var newQuality = item.Quality + qualityAdjustment;
        newQuality = newQuality < 0 ? 0 : newQuality;
        newQuality = newQuality > 50 ? 50 : newQuality;

        item.Quality = newQuality;
        item.SellIn += sellInAdjustment;
    }
}