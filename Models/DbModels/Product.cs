using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerceManager.Models
{
    public class Product : BaseEntity
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        // a product can have many orders therefore:
        public List<Order> Order { get; set; } // list to expect multiple order objects
        // must create an empty list in the single side of a one to many
        public Product()
        {
            Order = new List<Order>(); // new empty list of orders
        }
    }
}