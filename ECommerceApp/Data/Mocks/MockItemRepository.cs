using ECommerceApp.Data.Interfaces;
using ECommerceApp.Models;

namespace ECommerceApp.Data.Mocks
{
    public class MockItemRepository: IItemRepository
    {
        private readonly ICategoryRepository categories= new MockCategoryRepository();

        public IEnumerable<Item> GetAllItems
        { 
            get 
            {
                return new List<Item> 
                {
                new Item{
                    ItemId=1,
                    Name="Ura Maki",
                    Price=215,
                    Description="Yummy Ura Maki",
                    Category=categories.GetCategories.First(),
                    IsAvailable=true
                    },
                new Item{
                    ItemId=2,
                    Name="Onigiri",
                    Price=215,
                    Description="Yummy Onigiri",
                    Category=categories.GetCategories.First(),
                    IsAvailable=false
                    },
                new Item{
                    ItemId=3,
                    Name="Spider Roll",
                    Price=215,
                    Description="Yummy Spider Roll",
                    Category=categories.GetCategories.Last(),
                    IsAvailable=true
                    }
                };
            } 
        }
        //public IEnumerable<Item> GetItemsByCategory {
            
        //}
        public Item GetItemById(int id) { 
            throw new NotImplementedException();
        }


    }
}
