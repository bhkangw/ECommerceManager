using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ECommerceManager.Models;
// using ECommerceManager.Utils;

namespace ECommerceManager.Controllers
{
    public class HomeController : Controller
    {
        private Context _context;

        public HomeController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            // var customers = _context.customers.ToList(); // secondary method of displaying timeago for date, using Utils.cs
            // foreach (var customer in customers)
            // {
            //     customer.CreatedAtString = TimeUtils.TimeAgo(customer.CreatedAt);
            // }
            // ViewBag.customer = customers;

            ViewBag.customer = _context.customers.ToList();
            ViewBag.product = _context.products.ToList();
            ViewBag.order = _context.orders.Include(o => o.Customer).Include(o => o.Product).ToList();
            ViewBag.productsearch = null;
            return View();
        }

        [HttpPost]
        [Route("searchindex")]
        public IActionResult SearchIndex(string ProductSearch)
        {
            ViewBag.productsearch = _context.products.Where(p => p.ProductName.ToLower().Contains(ProductSearch.ToLower())).ToList();
            ViewBag.customer = _context.customers.ToList();
            ViewBag.product = _context.products.ToList();
            ViewBag.order = _context.orders.Include(o => o.Customer).Include(o => o.Product).ToList();
            return View("Index");
        }
    
    }
}
