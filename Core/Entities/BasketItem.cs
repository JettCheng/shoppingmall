namespace Core.Entities
{
    public class BasketItem
    {
        public int Id { get; set; }
        
        public string ProductTitle { get; set; }
        
        public decimal Price { get; set; }
        
        public int Quantity { get; set; }
        
        public string CoverImage { get; set; }
        
        public string ProductType { get; set; }
        
        
    }
}