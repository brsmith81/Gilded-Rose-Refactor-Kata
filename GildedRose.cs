using System.Collections.Generic;
using csharpcore;

namespace GildedRose
{
    public class GildedRose
    {
        readonly IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {

            foreach (StockItem item in Items)
            {
                item.Update();
            }

        }

    }
}
