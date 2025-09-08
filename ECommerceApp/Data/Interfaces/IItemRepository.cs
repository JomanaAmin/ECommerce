using ECommerceApp.Models;

namespace ECommerceApp.Data.Interfaces
{
    public interface IItemRepository
    {
        public IEnumerable <Item> GetAllItems { get; }
        //public IEnumerable<Item> GetItemsByCategory { get; }
        public Item GetItemById(int id);

    }
}
