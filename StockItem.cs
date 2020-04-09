using csharpcore;

namespace GildedRose
{
    public class StockItem : Item
    {
        readonly private IItemRules _updateRules;

        public StockItem( string Name, int Sellin, int Quality, IItemRules Rules )
        { 
            this.Name = Name;
            this.SellIn = Sellin;
            _updateRules = Rules;
            this.Quality = _updateRules.SetStartQuality( Quality );
        }

        public void Update()
        {
            this.Quality = _updateRules.UpdateQuality( this.Quality, this.SellIn );
            this.SellIn = _updateRules.UpdateSellIn( this.SellIn );
        }

    }
}
