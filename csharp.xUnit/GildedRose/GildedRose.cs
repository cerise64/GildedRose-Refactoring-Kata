using System;
using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;

    const string AgedBrie = "Aged Brie";
    const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
    const string Sulfuras = "Sulfuras, Hand of Ragnaros";
    const string Conjured = "Conjured";

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        int increaser = 0;
        int reducer = 0;
        for (var i = 0; i < Items.Count; i++)
        {
            // Manage Sulfuras
            if (Items[i].Name == Sulfuras)
            {
                continue;
            }
            ReduceSellIn(Items[i]);
            switch (Items[i].Name)
            {
                case BackstagePasses:
                    increaser = ComputeBackstageIncreaser(Items[i]);
                    if (increaser < 0)
                    {
                        Items[i].Quality = 0;
                    }
                    else
                    {
                        IncreaseQuality(Items[i], increaser);
                    }
                    break;
                case AgedBrie:
                    increaser = Items[i].SellIn < 0 ? 2 : 1;
                    IncreaseQuality(Items[i], increaser);
                    break;
                default:
                    reducer = Items[i].SellIn < 0 ? 2 : 1;
                    // Manage conjured
                    if (Items[i].Name == Conjured)
                    {
                        reducer = reducer * 2;
                    }
                    ReduceQuality(Items[i], reducer);
                    break;
            }
        }
    }

    /// <summary>
    /// Reduce item sellin by 1
    /// </summary>
    /// <param name="item"> Item to update </param>
    private void ReduceSellIn(Item item)
    {
        item.SellIn = item.SellIn - 1;
    }

    /// <summary>
    /// Reduce item quality by desired quantity
    /// </summary>
    /// <param name="item"> Item to update </param>
    /// <param name="quantity"> quality quantity to reduce </param>
    private void ReduceQuality(Item item, int quantity)
    {
        item.Quality = Math.Max(0, item.Quality - quantity);
    }

    /// <summary>
    /// Increase item quality by desired quantity
    /// </summary>
    /// <param name="item"> Item to update </param>
    /// <param name="quantity"> quality quantity to increase </param>
    private void IncreaseQuality(Item item, int quantity)
    {
        item.Quality = Math.Min(50, item.Quality + quantity);
    }

    /// <summary>
    /// Compute quality quantity to increase for the backstage item
    /// </summary>
    /// <param name="item"> Backstage item </param>
    /// <returns>
    /// -1 if quality should not be increased but set to 0
    /// 3 if SellIn is < 5
    /// 2 if SellIn is < 10
    /// 1 otherwise
    ///</returns>
    private int ComputeBackstageIncreaser(Item item)
    {
        switch (item.SellIn)
        {
            case < 0:
                return -1;
            case < 5:
                return 3;
            case < 10:
                return 2;
            default:
                return 1;
        }
    }
}