using ECommerceApp.Data.Interfaces;
using ECommerceApp.Models;
using Microsoft.EntityFrameworkCore; // Missing this!
using System.Linq;                  // Missing this!

namespace ECommerceApp.Data.Repositories
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly AppDbContext context;
        public CategoryRepository(AppDbContext context)
        { //inject appdbcontext service to interact with database
            this.context = context;
        }
        //public IEnumerable<Item> GetCategoryItems(Category category)
        //{
        //    IEnumberable<Item> categoryItems= ContextBoundObject.Items.Include(i=>i.Category).Where(i=)
        //}

        public IEnumerable<Category> GetCategories 
        {
            get
            { 
                IEnumerable<Category> categories= context.Categories.ToList();
                return categories;
            }
        }
    }
}
