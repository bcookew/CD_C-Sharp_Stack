using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductsAndCategories.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ProductsAndCategories.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ProductsAndCategoriesContext _context;

        public CategoryController(ILogger<HomeController> logger, ProductsAndCategoriesContext context)
        {
            _logger = logger;
            _context = context;
        }

        // ====================
        // ====================== Display Categories
        // ====================
        public IActionResult CategoriesView()
        {
            ViewBag.Categories = _context.Categories
                            .AsNoTracking()
                            .ToList();
            return View();
        }

        public IActionResult AddCategory(Category category)
        {
            if(ModelState.IsValid)
            {
                _context.Add(category);
                _context.SaveChanges();
                return RedirectToAction("CategoriesView");
            }
            else
            {
                return View("CategoriesView");
            }
        }

        [HttpGet("ViewCategory/{id}")]
        public IActionResult ViewCategory(int id)
        {
            CategoryPage cat = new CategoryPage();
            cat.Category = _context.Categories
                            .Include(cat => cat.AllProducts)
                                .ThenInclude(prod => prod.Product)
                            .AsNoTracking()
                            .SingleOrDefault(cat => cat.CategoryId == id);
            cat.Products = _context.Products
                            .Include(p => p.AllCategories)
                            .Where(p => p.AllCategories.Any(tag => tag.CategoryId != cat.Category.CategoryId))
                            .AsNoTracking().ToList();
            return View(cat);
        }

        // ====================
        // ====================== Home Route - Display Homepage
        // ====================
        
    }
}
