using csharpcore;

namespace GildedRose
{
    public class StockItem : Item
    {
        readonly private ItemRules _updateRules;

        public StockItem( string Name, int Sellin, int Quality, ItemRules Rules )
        { 
            this.Name = Name;
            this.SellIn = Sellin;
            _updateRules = Rules;
            this.Quality = _updateRules.SetStartQuality( Quality );
        }

        public void Update()
        {
            _updateRules.UpdateQuality( this );
            _updateRules.UpdateSellIn( this );
        }

    }
}
