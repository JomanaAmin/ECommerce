using ECommerceApp.Data.Interfaces;
using ECommerceApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;                 
namespace ECommerceApp.Data.Repositories
{
    public class ItemRepository:IItemRepository
    {
        private readonly AppDbContext context;
        public ItemRepository(AppDbContext context)
        { //inject appdbcontext service to interact with database
            this.context = context;
        }
        public IEnumerable<Item> GetAllItems 
        {
            get 
            {
                IEnumerable<Item> items = context.Items.Include(i=>i.Category).ToList();
                return items;
            } 
        }

        public IEnumerable<Item> GetItemsByCategory(Category category) 
        {
            IEnumerable<Item> items = context.Items.Include(i=>i.Category).Where(i => i.CategoryId == category.CategoryId).ToList();
            return items;
        }

        public Item GetItemById(int id) 
        {
            Item item = context.Items.Include(i=>i.Category).FirstOrDefault(i=>i.ItemId==id);
            return item;
        }
    }
}
