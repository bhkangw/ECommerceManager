using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ECommerceManager.Models;

namespace ECommerceManager.Controllers
{
    public class ProductController : Controller
    {
        private Context _context;

        public ProductController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("products")]
        public IActionResult Index()
        {
            ViewBag.product = _context.products.ToList();
            ViewBag.productsearch = null;
            return View();
        }


        [HttpPost]
        [Route("addproduct")]
        public IActionResult AddProduct(AddProduct newproduct)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product
                {
                    ProductName = newproduct.ProductName,
                    Image = newproduct.Image,
                    Description = newproduct.Description,
                    Quantity = newproduct.Quantity,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                };
                _context.products.Add(product);
                _context.SaveChanges();
                RedirectToAction("Index");
            }
            ViewBag.product = _context.products.ToList();
            return View("Index");
        }
        
        [HttpPost]
        [Route("searchproducts")]
        public IActionResult SearchProducts(string ProductSearch)
        {
            ViewBag.productsearch = _context.products.Where(p => p.ProductName.ToLower().Contains(ProductSearch.ToLower())).ToList();
            return View("Index");
        }
    }
}
