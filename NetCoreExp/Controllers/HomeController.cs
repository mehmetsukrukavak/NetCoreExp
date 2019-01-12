﻿using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NetCoreExp.Models;
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
            if (RouteData.Values["id"] == null)
            {
                return View(
                new ProductViewModel()
                {
                    Products = productRepository.Products.ToList(),
                    SelectedCategory = 0
                });
            }
            else
            {
                return View(
                new ProductViewModel()
                {
                    Products = productRepository.Products.Where(p => p.CategoryId.ToString() == RouteData.Values["id"].ToString()).ToList(),
                    SelectedCategory = Convert.ToInt32(RouteData.Values["id"])
                });
            }
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}