using csharpcore;

namespace GildedRose
{
    public class StockItem : Item
    {
        readonly private UpdateRules _updateRules;

        public StockItem( string Name, int Sellin, int Quality, UpdateRules Rules )
        { 
            this.Name = Name;
            this.SellIn = Sellin;
            this.Quality = Quality;
            _updateRules = Rules;
            _updateRules.SetStartQuality(this);

        }

        public void Update()
        {
            _updateRules.UpdateQuality( this );
            _updateRules.UpdateSellIn( this );
        }

    }
}
