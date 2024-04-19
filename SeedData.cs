using Microsoft.EntityFrameworkCore;
using ShopApplication.Data;
using ShopApplication.Models;

namespace ShopApplication
{
    public class SeedData
    {
        private readonly DataContext dataContext;
        public SeedData(DataContext context)
        {
            dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.Products.Any())
            {
                var products = new List<Product>
        {
            new Product
            {
                createAt = DateTime.Now,
                name = "Product 1",
                price = 10.99f,
                salePercentage = 0,
                imageUrl = "https://example.com/image1.jpg",
                status = "Active",
                category = "Tops",
                availableSize = {"Medium" },
                images = new List<Image>
                {
                    new Image
                    {
                        url = "https://example.com/image1.jpg",
                        width = 100,
                        height = 100,
                        createAT = DateTime.Now
                    },
                    new Image
                    {
                        url = "https://example.com/image2.jpg",
                        width = 200,
                        height = 200,
                        createAT = DateTime.Now
                    }
                },
                comments = new List<Comment>
                {
                    new Comment
                    {
                        createAt = DateTime.Now,
                        edited = false,
                        commentText = "Comment 1",
                    },
                    new Comment
                    {
                        createAt = DateTime.Now,
                        edited = false,
                        commentText = "Comment 2",
                    }
                }
            }
        };
                dataContext.Products.AddRange(products);
                dataContext.SaveChanges();
            }
        }
    }
}
