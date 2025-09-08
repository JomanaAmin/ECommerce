using ECommerceApp.Data.Interfaces;
using ECommerceApp.Models;

namespace ECommerceApp.Data.Mocks
{
    public class MockCategoryRepository: ICategoryRepository
    {
        //public IEnumerable<Item> GetCategoryItems { get; }
        public IEnumerable<Category> GetCategories
        {
            get {

                return new List<Category> {

                    new Category{
                        CategoryId=1,
                        Name="Fried Rolls",
                        Description="Yummy Fried Rolls",

                    },
                    new Category{
                        CategoryId=2,
                        Name="Raw Rolls",
                        Description="Yummy Raw Rolls",
}
                };
            
            }
        
        }

    }
}

