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
        public int Id { get; set; }
        public string Address { get; set; }

        public int userID { get; set; }

        public int price { get; set; }

        public Status OrderStatus { get; set; }
    }
}
