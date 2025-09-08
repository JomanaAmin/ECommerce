using ECommerceApp.Models;
namespace ECommerceApp.Data.ViewModels

{
    public class ItemListViewModel
    {
        public IEnumerable<Item> ItemsList { get; set; } 
        public String CurrentCategory { get; set; }
    }
}
