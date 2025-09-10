namespace ECommerceApp.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public string CartId { get; set; }
        //public Order Order { get; set; }

        //public int ItemId { get; set; }
        public Item Item { get; set; }

        public int Quantity { get; set; }

        //public decimal Price { get; set; } // Price at the time of order

    }
}
