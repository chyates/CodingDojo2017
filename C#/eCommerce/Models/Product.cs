using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace eCommerce.Models 
{
    public class Product : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
    }
}