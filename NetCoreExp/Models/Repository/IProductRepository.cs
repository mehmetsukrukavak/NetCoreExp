﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreExp.Models.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();

        void AddProduct(Product entity);
    }
}
