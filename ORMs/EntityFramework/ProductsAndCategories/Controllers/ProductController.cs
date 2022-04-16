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
                ViewBag.Prods = _context.Products
                            .AsNoTracking()
                            .ToList();
                return View("ProductsView");
            }
        }
        [HttpGet("Product/ViewProduct/{id}")]
        public IActionResult ViewProduct(int id)
        {
            ProductPage prod = BuildPageModel(id, _context);
            return View(prod);
        }
        // ====================
        // ====================== Add tag relationship
        // ====================
        public IActionResult AddTag(Tag tag)
        {
            if(ModelState.IsValid)
            {
                _context.Add(tag);
                _context.SaveChanges();
                return RedirectToAction("ViewProduct", new {id=tag.ProductId});
            }
            else
            {
                ProductPage prod = BuildPageModel(tag.ProductId, _context, tag);
                return View("ViewProduct", prod);
            }
        }

        public static ProductPage BuildPageModel(int id, ProductsAndCategoriesContext _context, Tag PassedTag = null)
        {
            ProductPage prod = new ProductPage();
            prod.Product = _context.Products
                            .Include(p => p.AllCategories)
                            .ThenInclude(allcats => allcats.Category)
                            .AsNoTracking().SingleOrDefault(p => p.ProductId == id);
            prod.Categories = _context.Categories
                                .Include(cat => cat.AllProducts)
                                .Where(cat => !cat.AllProducts.Any(tag => tag.CategoryId == cat.CategoryId && tag.ProductId == prod.Product.ProductId))
                                .AsNoTracking()
                                .ToList();
            
            if(PassedTag != null)
            {
                prod.Tag = PassedTag;
            }
            else
            {
                prod.Tag = new Tag();
            }
            return prod;

            // ====================== Old Filtering ***********************************************

            // var cats = _context.Categories
            //                     .Include(cats => cats.AllProducts)
            //                     .AsNoTracking()
            //                     .ToList();
            // List<Category> cat = new List<Category>();            
            // foreach(var c in cats)
            // {
            //     bool present = false;
            //     foreach (var tag in c.AllProducts)
            //     {
            //         if (tag.ProductId == prod.Product.ProductId)
            //         {
            //             present = true;
            //             break;
            //         }
            //     }
            //     if(present)
            //     {
            //         continue;
            //     }
            //     cat.Add(c);
            // }
            
        }
    }

}
