using System;
using csharpcore;

namespace GildedRose
{
    // I could also make the class implement a Interface, but YAGNI.  Don't need it at this time
    public class UpdateRules

    {
        // hardcode updateAmt in each class rather than passing in as a parameter
        // to prevent users from being able to vary requirements
        protected int updateAmt = -1;
        protected const int MinQuality = 0;
        protected const int MaxQuality = 50;

        virtual public void SetStartQuality( Item stockItem )
        {
            stockItem.Quality = Math.Max( MinQuality, Math.Min(MaxQuality, stockItem.Quality) );
        }
        virtual public void UpdateQuality( Item stockItem )
        {

            // once sell by date has passed, quality degrades twice as fast
            int updateFactor = (stockItem.SellIn <= 0) ? 2 : 1;

            stockItem.Quality = Math.Min(MaxQuality, Math.Max(MinQuality, stockItem.Quality + ( updateAmt * updateFactor )));
        }

        virtual public void UpdateSellIn(Item stockItem) => --stockItem.SellIn;

    }

    public class SulfurasRules : UpdateRules
    {
        protected new int updateAmt = 0;

        override public void SetStartQuality(Item stockItem) => stockItem.Quality = 80;

        override public void UpdateQuality( Item stockItem )
        {
        }

        override public void UpdateSellIn( Item stockItem )
        {
        }
    }

    public class AgedBrieRules : UpdateRules
    {
        public AgedBrieRules() => updateAmt = 1;
    }

    public class BackStageRules : UpdateRules
    {
        protected new int updateAmt = 1;

        override public void UpdateQuality(Item stockItem)
        {
            switch (stockItem.SellIn)
            {
                case var n when n <= 0:
                    stockItem.Quality = 0;
                    break;
                case var n when n < 6 :
                    stockItem.Quality = Math.Min(MaxQuality, Math.Max(MinQuality, stockItem.Quality + 3));
                    break;
                case var n when n < 11:
                    stockItem.Quality = Math.Min(MaxQuality, Math.Max(MinQuality, stockItem.Quality + 2));
                    break;
                default:
                    stockItem.Quality = Math.Min(MaxQuality, Math.Max(MinQuality, stockItem.Quality + updateAmt));
                    break;
            }
        }
    }

    public class ConjuredRules : UpdateRules
    {
        public ConjuredRules() => updateAmt = -2;
    }

}
