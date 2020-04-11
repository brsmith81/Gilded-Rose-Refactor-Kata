namespace GildedRose
{
    public static class ItemRuleFactory
    {
        public static IItemRules GetItemRule(string itemType)
        {
            IItemRules rule;

            switch (itemType)
            {
                case "+5 Dexterity Vest":
                    rule = new ItemRules();
                    break;
                case "Aged Brie":
                    rule = new AgedBrieRules();
                    break;
                case "Elixir of the Mongoose":
                    rule = new ItemRules();
                    break;
                case "Sulfuras, Hand of Ragnaros":
                    rule = new SulfurasRules();
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    rule = new BackStageRules();
                    break;
                case "Conjured Mana Cake":
                    rule = new ConjuredRules();
                    break;
                default:
                    rule = new ItemRules();
                    break;
            };
            return rule;
        }
    }
}
