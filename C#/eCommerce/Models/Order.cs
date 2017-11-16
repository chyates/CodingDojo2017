using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace eCommerce.Models 
{
    public class Order : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
    }
}