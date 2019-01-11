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

        public IViewComponentResult Invoke(bool isApproved)
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
            return View(viewName, new ProductSummaryViewModel()
            {
                Count = productRepository.Products.Where(a=> a.isApproved == isApproved).Count(),
                TotalPrice = productRepository.Products.Where(a => a.isApproved == isApproved).Sum(a => a.Price)
            });
            //return new HtmlContentViewComponentResult(new HtmlString($"<strong>{productRepository.Products.Count()}</strong> Adet Ürün, Toplam {productRepository.Products.Sum(a => a.Price)} TL."));
        }
    }
}
