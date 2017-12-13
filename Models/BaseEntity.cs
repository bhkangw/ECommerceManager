using System;

namespace ECommerceManager.Models
{
    public abstract class BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        // public string CreatedAtString;
        public DateTime UpdatedAt { get; set; }
    }
    
}