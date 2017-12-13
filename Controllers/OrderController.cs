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
    public class OrderController : Controller
    {
        private Context _context;

        public OrderController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("orders")]
        public IActionResult Index()
        {
            ViewBag.customer = _context.customers.ToList();
            ViewBag.product = _context.products.ToList();
            ViewBag.order = _context.orders.ToList();
            ViewBag.ordersearch = null;
            return View();
        }

        [HttpPost]
        [Route("addorder")]
        public IActionResult AddOrder(int Customer, int Quantity, int Product)
        {
            if (ModelState.IsValid)
            {
                Order order = new Order
                {
                    CustomerId = Customer,
                    ProductId = Product,
                    Quantity = Quantity,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                };
                _context.orders.Add(order);
                _context.SaveChanges();

                Product RetrievedProduct = _context.products.SingleOrDefault(product => product.ProductId == Product);
                RetrievedProduct.Quantity -= Quantity;
                _context.SaveChanges();

                ViewBag.customer = _context.customers.ToList();
                ViewBag.product = _context.products.ToList();
                ViewBag.order = _context.orders.Include(o => o.Customer).Include(o => o.Product).ToList();
                RedirectToAction("Index");
            }
            ViewBag.order = _context.orders.ToList();
            return View("Index");
        }

        [HttpPost]
        [Route("searchorders")]
        public IActionResult SearchOrder(string CustomerSearch)
        {
            ViewBag.ordersearch = _context.orders.Include(o => o.Customer).Where(o => o.Customer.CustomerName.ToLower().Contains(CustomerSearch.ToLower())).ToList();
            ViewBag.customer = _context.customers.ToList();
            ViewBag.product = _context.products.ToList();
            return View("Index");
        }
    }
}
