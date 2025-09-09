namespace ECommerceApp.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public bool IsAvailable { get; set; }

        public string imageUrl { get; set; } = string.Empty;

        public string imageThumbnailUrl { get; set; } = string.Empty;

    }
}
