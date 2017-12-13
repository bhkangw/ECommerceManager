using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerceManager.Models
{
    public class AddCustomer
    {
        [Display(Name = "Customer Name")]
        [Required]
        [MinLength(2)]
        public string CustomerName { get; set; }
    }
}