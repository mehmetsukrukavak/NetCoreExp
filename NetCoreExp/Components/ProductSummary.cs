using Microsoft.AspNetCore.Mvc;
using NetCoreExp.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreExp.Components
{
    public class ProductSummary:ViewComponent
    {
        private IProductRepository productRepository;

        public ProductSummary(IProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }

        public string Invoke()
        {
            return $"{productRepository.Products.Count()} Adet Ürün, {productRepository.Products.Sum(a => a.Price)} TL.";
        }
    }
}
