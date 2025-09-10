namespace ECommerceApp.Models
{

    public enum Status { 
        Pending,
        Confirmed,
        Preparing,
        OutForDelivery,
        Delivered
    }
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }

        public decimal Total { get; set; }

        public Status OrderStatus { get; set; }
        public IEnumerable<CartItem> OrderItems { get; set; }  
    }
}
