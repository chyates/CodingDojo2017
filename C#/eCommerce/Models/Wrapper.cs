using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace eCommerce.Models 
{
    public class Wrapper : BaseEntity 
    {
        public List<Customer> Customers { get; set; }
        public List<Product> Products { get; set; }
        public List<Order> Orders { get; set; }

        public Wrapper(List<Customer> customers, List<Product> products, List<Order> orders)
        {
            Customers = customers;
            Products = products;
            Orders = orders;
        }
    }
}