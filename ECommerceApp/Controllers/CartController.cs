using ECommerceApp.Data.Interfaces;
using ECommerceApp.Data.Repositories;
using ECommerceApp.Data.ViewModels;
using ECommerceApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IItemRepository itemRepository;
        private readonly Cart cart; 
        public CartController(IItemRepository itemRepository, Cart cart) 
        {
            this.itemRepository = itemRepository;   
            this.cart = cart;
        }
        public IActionResult ViewCart()
        {
            var items = cart.GetCartItems();
            var cartViewModel = new CartViewModel();
            cartViewModel.cart = cart;
            cartViewModel.total = cart.GetCartTotal();
            return View(cartViewModel);
        }
        public RedirectToActionResult AddToCart(int id) 
        {
            var item = itemRepository.GetItemById(id);
            if (item!=null) 
            {
                cart.AddToCart(item, 1);            
            
            }
            return RedirectToAction("ViewCart");
        }
        public RedirectToActionResult RemoveItemFromCart(int id) 
        {
            var item=itemRepository.GetItemById(id);
            if (item!=null) 
            {
                cart.RemoveCartItem(item, 1);
            }
            return RedirectToAction("ViewCart");
            
            
            
        }
    }
}
