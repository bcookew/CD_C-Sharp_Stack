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
                ViewBag.Categories = _context.Categories
                            .AsNoTracking()
                            .ToList();
                return View("CategoriesView");
            }
        }

        [HttpGet("ViewCategory/{id}")]
        public IActionResult ViewCategory(int id)
        {
            CategoryPage cat = BuildPageModel(id, _context);
            return View(cat);
        }

        // ====================
        // ====================== Add Tag to Category
        // ====================
        public IActionResult AddTag(Tag tag)
        {
            if(ModelState.IsValid)
            {
                _context.Add(tag);
                _context.SaveChanges();
                return RedirectToAction("ViewCategory", new {id=tag.CategoryId});
            }
            else
            {
                CategoryPage cat = BuildPageModel(tag.CategoryId, _context, tag);
                return View("ViewCategory", cat);
            }
        }
        public static CategoryPage BuildPageModel(int id, ProductsAndCategoriesContext _context, Tag PassedTag = null)
        {
            CategoryPage cat = new CategoryPage();
            cat.Category = _context.Categories
                            .Include(cat => cat.AllProducts)
                                .ThenInclude(prod => prod.Product)
                            .AsNoTracking()
                            .SingleOrDefault(cat => cat.CategoryId == id);
            cat.Products = _context.Products
                            .Include(p => p.AllCategories)
                            .Where(p => !p.AllCategories.Any(tag => tag.ProductId == p.ProductId && tag.CategoryId == cat.Category.CategoryId))
                            .AsNoTracking().ToList();
            if(PassedTag != null)
            {
                cat.Tag = PassedTag;
            }
            else
            {
                cat.Tag = new Tag();
            }
            return cat;
        }
    }
}
