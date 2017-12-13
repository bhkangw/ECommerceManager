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
    public class CustomerController : Controller
    {
        private Context _context;

        public CustomerController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("customers")]
        public IActionResult Index()
        {
            ViewBag.customer = _context.customers.ToList();
            return View();
        }

        [HttpPost]
        [Route("addcustomer")]
        public IActionResult AddCustomer(AddCustomer newcustomer)
        {
            if (_context.customers.Where(c => c.CustomerName == newcustomer.CustomerName).SingleOrDefault() != null)
                ModelState.AddModelError("CustomerName", "Cannot have repeat customers!"); // checking if customer name already exists in the db

            if(ModelState.IsValid)
            {
                Customer customer = new Customer
                {
                    CustomerName = newcustomer.CustomerName,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                };
                _context.customers.Add(customer);
                _context.SaveChanges();
                RedirectToAction("Index");
            }
            ViewBag.customer = _context.customers.ToList();
            ViewBag.customersearch = null;
            return View("Index");
        }

        [HttpPost]
        [Route("removecustomer")]
        public IActionResult RemoveCustomer(int CustomerId)
        {
            Customer ToDelete = _context.customers.SingleOrDefault(c => c.CustomerId == CustomerId);
            _context.Remove(ToDelete);
            _context.SaveChanges();
            
            ViewBag.customer = _context.customers.ToList();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("searchcustomers")]
        public IActionResult SearchCustomer(string CustomerSearch)
        {
            ViewBag.customersearch = _context.customers.Where(c => c.CustomerName.ToLower().Contains(CustomerSearch.ToLower())).ToList();
            return View("Index");
        }
    }
}
