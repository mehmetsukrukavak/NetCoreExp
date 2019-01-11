using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreExp.Models.Repository
{
    public class ProductRepository : IProductRepository
    {
        public void AddProduct(Product entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> Get()
        {
            throw new NotImplementedException();
        }
    }
}
