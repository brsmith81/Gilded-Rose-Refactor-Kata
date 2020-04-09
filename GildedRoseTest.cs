using System.Collections.Generic;
using Xunit;
using csharpcore;

namespace GildedRose
{
    public class GildedRoseTest
    {

        [Fact]
        public void Backstage()
        {
            IList<Item> Items = new List<Item> { new StockItem("Backstage passes to a TAFKAL80ETC concert", 11, 20, new BackStageRules()) };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(21, Items[0].Quality);
            Assert.Equal(10, Items[0].SellIn);

            app.UpdateQuality();
            Assert.Equal(23, Items[0].Quality);
            Assert.Equal(9, Items[0].SellIn);
        }

        [Fact]
        public void Backstage1()
        {
            IList<Item> Items = new List<Item> { new StockItem("Backstage passes to a TAFKAL80ETC concert", 6, 47, new BackStageRules()) };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(49, Items[0].Quality);
            Assert.Equal(5, Items[0].SellIn);

            app.UpdateQuality();
            Assert.Equal(50, Items[0].Quality);
            Assert.Equal(4, Items[0].SellIn);
        }

        [Fact]
        public void Backstage2()
        {
            IList<Item> Items = new List<Item> { new StockItem("Backstage passes to a TAFKAL80ETC concert", 1, 35, new BackStageRules()) };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(38, Items[0].Quality);
            Assert.Equal(0, Items[0].SellIn);

            app.UpdateQuality();
            Assert.Equal(0, Items[0].Quality);
            Assert.Equal(-1, Items[0].SellIn);
        }

        [Fact]
        public void Sulfuras()
        {
            IList<Item> Items = new List<Item> { new StockItem("Sulfuras, Hand of Ragnaros", 2, 80, new SulfurasRules()) };
            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();
            Assert.Equal(80, Items[0].Quality);
            Assert.Equal(2, Items[0].SellIn);

            app.UpdateQuality();
            Assert.Equal(80, Items[0].Quality);
            Assert.Equal(2, Items[0].SellIn);
        }

        [Fact]
        public void SulfurasQualityIsResetTo80()
        {
            IList<Item> Items = new List<Item> { new StockItem("Sulfuras, Hand of Ragnaros", -1, 20, new SulfurasRules()) };
            GildedRose app = new GildedRose(Items);

            Assert.Equal(80, Items[0].Quality);
            Assert.Equal(-1, Items[0].SellIn);
        }

        [Fact]
        public void AgedBrie()
        {
            IList<Item> Items = new List<Item> { new StockItem("Aged Brie", 2, 0, new AgedBrieRules()) };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(1, Items[0].Quality);
            Assert.Equal(1, Items[0].SellIn);

            app.UpdateQuality();
            Assert.Equal(2, Items[0].Quality);
            Assert.Equal(0, Items[0].SellIn);

            app.UpdateQuality();
            Assert.Equal(4, Items[0].Quality);
            Assert.Equal(-1, Items[0].SellIn);
        }

        [Fact]
        public void AgedBrie50()
        {
            IList<Item> Items = new List<Item> { new StockItem("Aged Brie", 2, 50, new AgedBrieRules()) };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(50, Items[0].Quality);
            Assert.Equal(1, Items[0].SellIn);
        }

        [Fact]
        public void Conjured()
        {
            IList<Item> Items = new List<Item> { new StockItem("Conjured Mana Cake", 2, 6, new ConjuredRules()) };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(4, Items[0].Quality);
            Assert.Equal(1, Items[0].SellIn);

            app.UpdateQuality();
            Assert.Equal(2, Items[0].Quality);
            Assert.Equal(0, Items[0].SellIn);
        }

    }
}
