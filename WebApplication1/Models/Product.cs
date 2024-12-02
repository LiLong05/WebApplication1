﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}