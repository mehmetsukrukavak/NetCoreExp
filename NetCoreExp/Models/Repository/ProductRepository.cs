using System.Collections.Generic;

namespace NetCoreExp.Models.Repository
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> products = new List<Product>()
        {
            new Product(){ ProductId = 1, ProductName = "Apple Macbook Air 2018", Price=9000, isApproved=true, CategoryId=1 },
            new Product(){ ProductId = 2, ProductName = "Apple Macbook Air 2017", Price=7000, isApproved=false, CategoryId=1 },
            new Product(){ ProductId = 3, ProductName = "Apple Macbook Pro", Price=10000, isApproved=true, CategoryId=1 },

            new Product(){ ProductId = 4, ProductName = "Apple Iphone  7", Price=3000, isApproved=true, CategoryId=2 },
            new Product(){ ProductId = 5, ProductName = "Apple Iphone  8", Price=7000, isApproved=true, CategoryId=2 },
            new Product(){ ProductId = 6, ProductName = "Apple Iphone X", Price=15000, isApproved=true, CategoryId=2 },

            new Product(){ ProductId = 7, ProductName = "Apple Ipad 2018", Price=2500, isApproved=true, CategoryId=3 },
            new Product(){ ProductId = 8, ProductName = "Apple Ipad 2017", Price=6500, isApproved=false, CategoryId=3 },
            new Product(){ ProductId = 9, ProductName = "Apple Ipad Air", Price=7900, isApproved=true, CategoryId=3 },
            new Product(){ ProductId = 10, ProductName = "Apple Ipad Pro", Price=3000, isApproved=true, CategoryId=3 }
        };

        public IEnumerable<Product> Products => products;

        public void AddProduct(Product entity)
        {
            products.Add(entity);
        }


    }
}
