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
    public class ProductController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ProductsAndCategoriesContext _context;

        public ProductController(ILogger<HomeController> logger, ProductsAndCategoriesContext context)
        {
            _logger = logger;
            _context = context;
        }
        
        // ====================
        // ====================== Home Route - Display Products
        // ====================
        public IActionResult ProductsView()
        {
            ViewBag.Prods = _context.Products
                            .AsNoTracking()
                            .ToList();
            return View();
        }

        // ====================
        // ====================== New Product Validate and Save
        // ====================
        public IActionResult AddProduct(Product product)
        {
            if(ModelState.IsValid)
            {
                _context.Add(product);
                _context.SaveChanges();
                return RedirectToAction("ProductsView");
            }
            else
            {
                return View("ProductsView");
            }
        }
        [HttpGet("ViewProduct/{id}")]
        public IActionResult ViewProduct(int id)
        {
            ProductPage prod = new ProductPage();
            prod.Product = _context.Products
                            .Include(p => p.AllCategories)
                            .ThenInclude(allcats => allcats.Category)
                            .AsNoTracking().SingleOrDefault(p => p.ProductId == id);
            var cats = _context.Categories
                                .Include(cats => cats.AllProducts)
                                .ToList();
            List<Category> cat = new List<Category>();            
            foreach(var c in cats)
            {
                bool present = false;
                foreach (var tag in c.AllProducts)
                {
                    if (tag.ProductId == prod.Product.ProductId)
                    {
                        present = true;
                        break;
                    }
                }
                if(present)
                {
                    continue;
                }
                cat.Add(c);
            }
            prod.Categories = cat;
            prod.Tag = new Tag();
            return View(prod);
        }

        // public IActionResult AddCategory()
    }
}
