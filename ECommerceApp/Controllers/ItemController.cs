using ECommerceApp.Data.Interfaces;
using ECommerceApp.Data.ViewModels;
using ECommerceApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemRepository itemRepository;
        private readonly ICategoryRepository categoryRepository;
        public ItemController(IItemRepository itemRepository, ICategoryRepository categoryRepository)
        {
            this.itemRepository = itemRepository;
            this.categoryRepository = categoryRepository;
        }
        public IActionResult ViewAllItems()
        {
            ItemListViewModel items= new ItemListViewModel(); 
            items.ItemsList=itemRepository.GetAllItems;
            items.CurrentCategory="All Categories";
            return View(items);
        }
        public IActionResult FindItemById(int id) { 
            Item item=itemRepository.GetItemById(id);
            return View(item);
        }
        //public IActionResult ViewByCategory(Category Category) {
        //    ItemListViewModel items = new ItemListViewModel();
        //    items.ItemsList = itemRepository.GetItemsByCategory(Category);

        //    return View(items);
        //}
    }
}
