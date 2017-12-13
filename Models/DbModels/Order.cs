using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerceManager.Models
{
    public class Order : BaseEntity
    {
        [Key]
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int Quantity { get; set; }
    }
}
