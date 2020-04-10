using csharpcore;

namespace GildedRose
{
    public class StockItem : Item
    {
        readonly private IItemRules _updateRules;

        //public StockItem(string name, int sellIn, int quality, IItemRules Rules)
        public StockItem( string name, int sellIn, int quality )
        { 
            this.Name = name;
            this.SellIn = sellIn;
            //    _updateRules = Rules;
            _updateRules = ItemTypeFactory.GetItemRule( name );
            this.Quality = _updateRules.SetStartQuality( quality );
        }

        public void Update()
        {
            this.Quality = _updateRules.UpdateQuality( this.Quality, this.SellIn );
            this.SellIn = _updateRules.UpdateSellIn( this.SellIn );
        }

    }
}
