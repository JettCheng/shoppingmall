namespace Core.Entities
{
    public class BasketItem
    {
        public string Id { get; set; }
        
        public string ProductTitle { get; set; }
        
        public decimal Price { get; set; }
        
        public int Quantity { get; set; }
        
        public string CoverImage { get; set; }
        
        public string ProductType { get; set; }
        
        
    }
}