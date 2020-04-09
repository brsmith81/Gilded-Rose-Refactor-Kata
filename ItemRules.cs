using System;
using csharpcore;

namespace GildedRose
{
    // I could also make the class implement a Interface, but YAGNI.  Don't need it at this time
    public class ItemRules

    {
        // hardcode updateAmt in each class rather than passing in as a parameter
        // to prevent users from being able to vary requirements
        protected int updateAmt = -1;
        protected const int MinQuality = 0;
        protected const int MaxQuality = 50;

        virtual public int SetStartQuality( int quality )
        {
            return Math.Max( MinQuality, Math.Min(MaxQuality, quality) );
        }

        virtual public int UpdateQuality( int quality, int sellIn )
        {

            // once sell by date has passed, quality degrades twice as fast
            int updateFactor = (sellIn <= 0) ? 2 : 1;

            //stockItem.Quality = Math.Min(MaxQuality, Math.Max(MinQuality, stockItem.Quality + (updateAmt * updateFactor)));
            return Math.Min(MaxQuality, Math.Max(MinQuality, quality + ( updateAmt * updateFactor )));
        }

        virtual public int UpdateSellIn( int sellIn)
        {
            return --sellIn;
        }
    }

    public class SulfurasRules : ItemRules
    {
        protected new int updateAmt = 0;

        override public int SetStartQuality(int quality)
        {
            return 80;
        }

        override public int UpdateQuality(int quality, int sellIn )
        {
            return quality;
        }

        override public int UpdateSellIn( int sellIn )
        {
            return sellIn;
        }
    }

    public class AgedBrieRules : ItemRules
    {
        public AgedBrieRules()
        {
            updateAmt = 1;
        }
    }

    public class BackStageRules : ItemRules
    {
        protected new int updateAmt = 1;

        override public int UpdateQuality( int quality, int sellIn )
        {
            int updatedQuality;

            switch (sellIn)
            {
                case var n when n <= 0:
                    updatedQuality = 0;
                    break;
                case var n when n < 6 :
                    updatedQuality = Math.Min(MaxQuality, Math.Max(MinQuality, quality + 3));
                    break;
                case var n when n < 11:
                    updatedQuality = Math.Min(MaxQuality, Math.Max(MinQuality, quality + 2));
                    break;
                default:
                    updatedQuality = Math.Min(MaxQuality, Math.Max(MinQuality, quality + updateAmt));
                    break;
            }
            return updatedQuality;
        }
    }

    public class ConjuredRules : ItemRules
    {
        public ConjuredRules()
        {
            updateAmt = -2;
        }
    }

}
