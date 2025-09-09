namespace ECommerceApp.Models
{
    public class Category
    {

        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        //public List<Item> Items { get; set; } = new List<Item>();   

        public string imageUrl { get; set; } = string.Empty;

        public string imageThumbnailUrl { get; set; } = string.Empty;
    }
}
