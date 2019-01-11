using System.Collections.Generic;

namespace NetCoreExp.Models.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }

        void AddProduct(Product entity);
    }
}
