using Microsoft.AspNetCore.Mvc;
using NetCoreExp.Models.Repository;

namespace NetCoreExp.Controllers
{
    public class HomeController : Controller
    {
        private ICategoryRepository categoryRepository;
        private IProductRepository productRepository;

        public HomeController(ICategoryRepository _categoryRepository, IProductRepository _productRepository)
        {
            categoryRepository = _categoryRepository;
            productRepository = _productRepository;
        }
        public IActionResult Index()
        {
            return View(productRepository.Products);
        }
    }
}