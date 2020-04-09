namespace GildedRose
{
    public interface IItemRules
    {
        int SetStartQuality(int quality);
        int UpdateQuality(int quality, int sellIn);
        int UpdateSellIn(int sellIn);
    }
}