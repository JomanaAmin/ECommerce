using ECommerceApp.Models;

namespace ECommerceApp.Data.Interfaces
{
    public interface ICategoryRepository
    {
        //public IEnumerable<Item> GetCategoryItems(Category category);
        public IEnumerable<Category> GetCategories { get; }

    }
}

