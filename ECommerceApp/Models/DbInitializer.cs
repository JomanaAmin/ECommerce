using ECommerceApp.Data;
using System.Drawing.Text;
using static System.Formats.Asn1.AsnWriter;

namespace ECommerceApp.Models
{
    public class DbInitializer
    {
        public static void Seed(IServiceProvider serviceProvider) 
        {
            using (var scope=serviceProvider.CreateScope())
            { 
                //AppDbContext context = applicationBuilder.ApplicationServices.GetRequiredService<AppDbContext>();
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                // Ensure database is created and migrated
                context.Database.EnsureCreated();

                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(Categories.Select(c=>c.Value));

                }
                if (!context.Items.Any())
                {
                    context.Items.AddRange(
                        new Item {Name="Sweet & Sour Noodles",Price=190, Description="Sweet chicken with sour sauce noodles.", Category = Categories["Noodles"], IsAvailable=true, imageUrl= "https://www.cottercrunch.com/wp-content/uploads/2020/02/sweet-and-sour-noodles.jpg.webp" },
                        new Item {Name="Curry Noodles",Price=150, Description="Curry chicken with salad noodles.", Category = Categories["Noodles"], IsAvailable=true,imageUrl= "https://th.bing.com/th/id/R.ff61902a10d751fc73d89316f885b8b9?rik=J%2fzcArB8YT9wrw&pid=ImgRaw&r=0" },
                        new Item {Name="Tandoori Noodles",Price=200, Description="Best Tandoori noodles with chicken and beef.", Category = Categories["Noodles"], IsAvailable=true, imageUrl= "https://tse1.mm.bing.net/th/id/OIP.dSXQabiYxGeT04xRPeVZNQHaFJ?cb=ucfimg2ucfimg=1&rs=1&pid=ImgDetMain&o=7&rm=3" },
                        new Item {Name="Sweet & Sour Noodles",Price=190, Description="Sweet chicken with sour sauce noodles.", Category = Categories["Noodles"], IsAvailable=true, imageUrl= "https://www.cottercrunch.com/wp-content/uploads/2020/02/sweet-and-sour-noodles.jpg.webp" },
                        new Item {Name="Curry Noodles",Price=150, Description="Curry chicken with salad noodles.", Category = Categories["Noodles"], IsAvailable=true,imageUrl= "https://th.bing.com/th/id/R.ff61902a10d751fc73d89316f885b8b9?rik=J%2fzcArB8YT9wrw&pid=ImgRaw&r=0" },
                        new Item {Name="Tandoori Noodles",Price=200, Description="Best Tandoori noodles with chicken and beef.", Category = Categories["Noodles"], IsAvailable=true, imageUrl= "https://tse1.mm.bing.net/th/id/OIP.dSXQabiYxGeT04xRPeVZNQHaFJ?cb=ucfimg2ucfimg=1&rs=1&pid=ImgDetMain&o=7&rm=3" },
                        new Item {Name="Sweet & Sour Noodles",Price=190, Description="Sweet chicken with sour sauce noodles.", Category = Categories["Noodles"], IsAvailable=true, imageUrl= "https://www.cottercrunch.com/wp-content/uploads/2020/02/sweet-and-sour-noodles.jpg.webp" },
                        new Item {Name="Curry Noodles",Price=150, Description="Curry chicken with salad noodles.", Category = Categories["Noodles"], IsAvailable=true,imageUrl= "https://th.bing.com/th/id/R.ff61902a10d751fc73d89316f885b8b9?rik=J%2fzcArB8YT9wrw&pid=ImgRaw&r=0" },
                        new Item {Name="Tandoori Noodles",Price=200, Description="Best Tandoori noodles with chicken and beef.", Category = Categories["Noodles"], IsAvailable=true, imageUrl= "https://tse1.mm.bing.net/th/id/OIP.dSXQabiYxGeT04xRPeVZNQHaFJ?cb=ucfimg2ucfimg=1&rs=1&pid=ImgDetMain&o=7&rm=3" }
                    
                        );

                }

                context.SaveChanges();
            }
            
        }

        private static Dictionary<string, Category> categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {

                if (categories == null)
                {
                    var defaultCategories = new Category[]
                    {
                        new Category{ Name="Noodles", Description="Delicious Noodles! yum"},
                        new Category{ Name="Sushi", Description="Delicious Sushi! yum"}
                    };
                    categories = new Dictionary<string, Category>();
                    foreach (Category category in defaultCategories) {
                        categories.Add(category.Name,category);
                    }

                
                }
                return categories;
            }

        }
    }
}
