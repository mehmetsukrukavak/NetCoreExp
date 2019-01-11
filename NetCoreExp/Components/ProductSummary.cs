using Microsoft.AspNetCore.Mvc;
using NetCoreExp.Models;
using NetCoreExp.Models.Repository;
using System.Linq;

namespace NetCoreExp.Components
{
    public class ProductSummary : ViewComponent
    {
        private IProductRepository productRepository;

        public ProductSummary(IProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }

        public IViewComponentResult Invoke(int CategoryId, bool isApproved)
        {
            var viewName = "";
            if (isApproved)
            {
                viewName = "GreenCard";
            }
            else
            {
                viewName = "RedCard";
            }

            var products = CategoryId != 0 ? 
            
                productRepository.Products.Where(a => a.CategoryId == CategoryId && a.isApproved == isApproved) :
                productRepository.Products.Where(a => a.isApproved == isApproved);


            return View(viewName, new ProductSummaryViewModel()
            {
                Count = products.Count(),
                TotalPrice = products.Sum(a => a.Price)
            });
            //return new HtmlContentViewComponentResult(new HtmlString($"<strong>{productRepository.Products.Count()}</strong> Adet Ürün, Toplam {productRepository.Products.Sum(a => a.Price)} TL."));
        }
    }
}
