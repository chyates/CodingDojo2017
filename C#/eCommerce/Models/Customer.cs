using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace eCommerce.Models 
{
    public class Customer : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Order> Orders { get; set; }

        public Customer()
        {
            List<Order> Orders = new List<Order>();
        }
    }
}