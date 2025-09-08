using ECommerceApp.Models;

namespace ECommerceApp.Data.Interfaces
{
    public interface ICategoryRepository
    {
        //public IEnumerable <Item> GetCategoryItems { get; }
        public IEnumerable<Category> GetCategories { get; }

    }
}

