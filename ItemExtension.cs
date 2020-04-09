namespace csharpcore
{
    public static class ItemExtension
    {
        public static string FormatForOutput( this Item item )
        {
            return item.Name + ", " + item.SellIn + ", " + item.Quality;
        }  
    }
}
