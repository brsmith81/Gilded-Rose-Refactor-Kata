using System;
using System.Collections.Generic;
using csharpcore;

namespace GildedRose
{
    public class Program
    {
        public static void Main( )
        {
            Console.WriteLine("OMGHAI!");

            IList<Item> Items = LoadInventory();

            var app = new GildedRose(Items);
   
            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < Items.Count; j++)
                {
                    //System.Console.WriteLine(Items[j]);
                    System.Console.WriteLine(Items[j].FormatForOutput());
                }
                Console.WriteLine("");
                app.UpdateItems();
            }
        }

        private static IList<Item> LoadInventory()
        {
            return new List<Item>{
                new StockItem( "+5 Dexterity Vest", 10, 20, new UpdateRules() ),
                new StockItem( "Aged Brie", 2, 0, new AgedBrieRules() ),
                new StockItem( "Elixir of the Mongoose", 5, 7, new UpdateRules() ),
                new StockItem( "Sulfuras, Hand of Ragnaros", 0, 80, new SulfurasRules() ),
                new StockItem( "Sulfuras, Hand of Ragnaros", -1, 80, new SulfurasRules() ),
                new StockItem( "Backstage passes to a TAFKAL80ETC concert", 15, 20, new BackStageRules() ),
                new StockItem( "Backstage passes to a TAFKAL80ETC concert", 10, 49, new BackStageRules() ),
                new StockItem( "Backstage passes to a TAFKAL80ETC concert", 5, 49, new BackStageRules() ),
				new StockItem( "Conjured Mana Cake", 3, 6, new ConjuredRules() )
            };
        }
    }
}
