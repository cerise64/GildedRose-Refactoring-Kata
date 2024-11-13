using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    /// <summary>
    /// Quality should never be < 0
    /// </summary>
    [Fact]
    public void Quality0()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(0, Items[0].Quality);
    }

    /// <summary>
    /// Quality should never be > 50
    /// Test with AgedBrie item
    /// </summary>
    [Fact]
    public void Quality50AgedBrie()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 20, Quality = 50 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(50, Items[0].Quality);
    }

    /// <summary>
    /// Quality should never be > 50
    /// Test with Backstage item
    /// </summary>
    [Fact]
    public void Quality50Backstage()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 20, Quality = 50 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(50, Items[0].Quality);
    }

    /// <summary>
    /// Backstage behaviour when SellIn > 10
    /// </summary>
    [Fact]
    public void BackstageBefore10Deadline()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 30 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(31, Items[0].Quality);
    }

    /// <summary>
    /// Backstage behaviour when SellIn > 5
    /// </summary>
    [Fact]
    public void BackstageBefore5Deadline()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 30 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(32, Items[0].Quality);
    }

    /// <summary>
    /// Backstage behaviour when 0 > SellIn > 5
    /// </summary>
    [Fact]
    public void BackstageBeforeDeadline()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 30 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(33, Items[0].Quality);
    }

    /// <summary>
    /// Backstage behaviour when SellIn = 0
    /// </summary>
    [Fact]
    public void BackstageDeadline()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 50 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(0, Items[0].Quality);
    }

    /// <summary>
    /// AgedBrie behaviour when SellIn > 0
    /// </summary>
    [Fact]
    public void AgedBrieBeforeDeadline()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 40 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(41, Items[0].Quality);
    }

    /// <summary>
    /// AgedBrie behaviour when SellIn < 0
    /// </summary>
    [Fact]
    public void AgedBrieDeadline()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 40 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(42, Items[0].Quality);
    }

    /// <summary>
    /// Conjured behaviour when SellIn > 0
    /// </summary>
    [Fact]
    public void ConjuredBeforeDeadLine()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Conjured", SellIn = 20, Quality = 30 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(28, Items[0].Quality);
    }

    /// <summary>
    /// Conjured behaviour when SellIn < 0
    /// </summary>
    [Fact]
    public void ConjuredAfterDeadLine()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Conjured", SellIn = 0, Quality = 30 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(26, Items[0].Quality);
    }

    /// <summary>
    /// Sulfuras quality behaviour
    /// </summary>
    [Fact]
    public void SulfurasQuality()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(80, Items[0].Quality);
    }

    /// <summary>
    /// Sulfuras sell in behaviour
    /// </summary>
    [Fact]
    public void SulfurasDeadline()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(10, Items[0].SellIn);
    }
}