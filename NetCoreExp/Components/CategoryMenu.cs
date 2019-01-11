using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NetCoreExp.Models;
using NetCoreExp.Models.Repository;

namespace NetCoreExp.Components
{
    public class CategoryMenu : ViewComponent
    {
        private ICategoryRepository categoryRepository;

        public CategoryMenu(ICategoryRepository _categoryRepository)
        {
            categoryRepository = _categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            return View(
            new CategoryViewModel()
            {
                Categories = categoryRepository.Categories.ToList(),
                SelectedCategory = RouteData.Values["id"] as String
            });
        }
    }
}
