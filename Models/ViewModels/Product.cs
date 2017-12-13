using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerceManager.Models
{
    public class AddProduct
    {
        [Required]
        [Display(Name = "Name")]
        [MinLength(2)]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Image (url)")]
        [Url]
        // [Uri(ErrorMessage = "Enter a valid url")]
        [MinLength(2)]
        public string Image { get; set; }

        [Required]
        [Display(Name = "Description")]
        [MinLength(2)]
        public string Description { get; set; }

        [Required]
        [Range(1, 100)]
        [Display(Name = "Initial Quantity")]
        public int Quantity { get; set; }
    }

    // public class UriAttribute : ValidationAttribute
    // {
    //     protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    //     {
    //         Uri uri;
    //         bool valid = Uri.TryCreate(Convert.ToString(value), UriKind.Absolute, out uri);

    //         if (!valid)
    //         {
    //             return new ValidationResult(ErrorMessage);
    //         }
    //         return ValidationResult.Success;
    //     }
    // }
}