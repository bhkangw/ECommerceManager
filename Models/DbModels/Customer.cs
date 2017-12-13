using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerceManager.Models
{
    public class Customer : BaseEntity
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        // a customer can have many orders therefore:
        public List<Order> Order { get; set; } // list to expect multiple order objects
        // must create an empty list in the single side of a one to many
        public Customer()
        {
            Order = new List<Order>(); // new empty list of orders
        }
    }
}