using System.Collections.Generic;
using Xunit;
using csharpcore;

namespace GildedRose
{
    public class GildedRoseTest
    {

        [Fact]
        public void QualityNeverMoreThan50Test()
        {
            IList<Item> Items = new List<Item> { new StockItem("New Stock Item", 11, 55) };
            var app = new GildedRose(Items);
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void FieldDecreaseByDefaultValuesTest()
        {
            IList<Item> Items = new List<Item> { new StockItem("New Stock Item", 1, 6) };
            var app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(5, Items[0].Quality);
            Assert.Equal(0, Items[0].SellIn);

            app.UpdateQuality();
            Assert.Equal(3, Items[0].Quality);
            Assert.Equal(-1, Items[0].SellIn);
        }

        [Fact]
        public void Backstage10DayBoundryTest()
        {
            IList<Item> Items = new List<Item> { new StockItem("Backstage passes to a TAFKAL80ETC concert", 11, 20) };
            var app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(21, Items[0].Quality);
            Assert.Equal(10, Items[0].SellIn);

            app.UpdateQuality();
            Assert.Equal(23, Items[0].Quality);
            Assert.Equal(9, Items[0].SellIn);
        }

        [Fact]
        public void Backstage5DayBoundryTest()
        {
            IList<Item> Items = new List<Item> { new StockItem("Backstage passes to a TAFKAL80ETC concert", 6, 20 ) };
            var app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(22, Items[0].Quality);
            Assert.Equal(5, Items[0].SellIn);

            app.UpdateQuality();
            Assert.Equal(25, Items[0].Quality);
            Assert.Equal(4, Items[0].SellIn);
        }

        [Fact]
        public void Backstage0DayBoundryTest()
        {
            IList<Item> Items = new List<Item> { new StockItem("Backstage passes to a TAFKAL80ETC concert", 1, 35) };
            var app = new GildedRose(Items);

            app.UpdateQuality();
            Assert.Equal(38, Items[0].Quality);
            Assert.Equal(0, Items[0].SellIn);

            app.UpdateQuality();
            Assert.Equal(0, Items[0].Quality);
            Assert.Equal(-1, Items[0].SellIn);
        }

        [Fact]
        public void SulfurasValuesDoNotChangeTest()
        {
            IList<Item> Items = new List<Item> { new StockItem("Sulfuras, Hand of Ragnaros", 2, 80 ) };
            var app = new GildedRose(Items);

            app.UpdateQuality();
            Assert.Equal(80, Items[0].Quality);
            Assert.Equal(2, Items[0].SellIn);

            app.UpdateQuality();
            Assert.Equal(80, Items[0].Quality);
            Assert.Equal(2, Items[0].SellIn);
        }

        [Fact]
        public void SulfurasStartQualitySetTo80Test()
        {
            IList<Item> Items = new List<Item> { new StockItem("Sulfuras, Hand of Ragnaros", -1, 20 ) };
            new GildedRose(Items);

            Assert.Equal(80, Items[0].Quality);
            Assert.Equal(-1, Items[0].SellIn);
        }

        [Fact]
        public void AgedBrieQualityIncreasesTest()
        {
            IList<Item> Items = new List<Item> { new StockItem("Aged Brie", 2, 0 ) };
            var app = new GildedRose(Items);
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
        public void AgedBrieQualityNeverOver50Test()
        {
            IList<Item> Items = new List<Item> { new StockItem("Aged Brie", 2, 50 ) };
            var app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(50, Items[0].Quality);
            Assert.Equal(1, Items[0].SellIn);
        }

        [Fact]
        public void ConjuredQualityDecreaseByDoubleDefaultTest()
        {
            IList<Item> Items = new List<Item> { new StockItem("Conjured Mana Cake", 2, 6) };
            var app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(4, Items[0].Quality);
            Assert.Equal(1, Items[0].SellIn);

            app.UpdateQuality();
            Assert.Equal(2, Items[0].Quality);
            Assert.Equal(0, Items[0].SellIn);

            app.UpdateQuality();
            Assert.Equal(0, Items[0].Quality);
            Assert.Equal(-1, Items[0].SellIn);
        }

    }
}
