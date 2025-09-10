using ECommerceApp.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Models
{
    public class Cart
    {
        private readonly AppDbContext context;
        public Cart(AppDbContext context)
        { //inject appdbcontext service to interact with database
            this.context = context;
        }
        public string CartId { get; set; }
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
        //public int UserId { get; set; }
        //public User User { get; set; }
        //public List<CartItem> CartItems { get; set; } = new List<CartItem>();
        //public decimal TotalPrice 
        //{ 
        //    get 
        //    {
        //        return CartItems.Sum(ci => ci.Item.Price * ci.Quantity);
        //    }
        //}
        public static Cart GetCart(IServiceProvider service) 
        { 
            ISession session = service.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;
            var context= service.GetService<AppDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);
            return new Cart(context) { CartId = cartId };
        }

        public void AddToCart(Item item, int quantity)
        {
            var cartItem = context.CartItems.SingleOrDefault(ci => ci.Item.ItemId == item.ItemId && ci.CartId == this.CartId);
            if (cartItem == null) {
                context.CartItems.Add(new CartItem
                {
                    Item = item,
                    Quantity = quantity
                });
            }
            else 
            { 
                cartItem.Quantity += quantity;
            }
            context.SaveChanges();
        }

        public int RemoveCartItem(Item item, int quantity) 
        {
            int amountLeft = 0;
            var cartItem = context.CartItems.SingleOrDefault(ci=>ci.Item.ItemId==item.ItemId && ci.CartId == this.CartId);
            if (cartItem!=null) {
                if (cartItem.Quantity>1) 
                { 
                    cartItem.Quantity -= quantity;
                    amountLeft = cartItem.Quantity;
                }
                else 
                { context.CartItems.Remove(cartItem); }

            }
            context.SaveChanges();
            return amountLeft;
        }

        public IEnumerable<CartItem> GetCartItems()
        {
            return this.CartItems ??(this.CartItems=context.CartItems.Where(ci=>ci.CartId==this.CartId).Include(s=>s.Item).ToList());
        }

        public void ClearCart() 
        {
            var allCartItems = context.CartItems.Where(ci => ci.CartId == this.CartId);
            context.CartItems.RemoveRange(allCartItems);
            context.SaveChanges();
        }
        public decimal GetCartTotal()
        {
            var total = context.CartItems.Where(ci => ci.CartId == this.CartId).Select(c => c.Item.Price * c.Quantity).Sum();
            return total;
           
        }
    }
}
