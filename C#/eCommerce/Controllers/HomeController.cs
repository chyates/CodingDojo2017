using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Session;
using eCommerce.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace eCommerce.Controllers
{
    public class HomeController : Controller
    {

        private ProductContext _context;

        public HomeController(ProductContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/dashboard")]
        public IActionResult Dashboard()
        {
            List<Customer> customers = _context.Customers.Include(c => c.Orders).ToList();
            List<Product> products = _context.Products.ToList();
            List<Order> orders = _context.Orders.ToList();

            Wrapper model = new Wrapper(customers, products, orders);
            return View(model);
        }        

        [HttpGet]
        [Route("/orders")]
        public IActionResult Orders()
        {
            List<Customer> customers = _context.Customers.Include(c => c.Orders).Take(5).ToList();
            List<Product> products = _context.Products.Take(5).ToList();
            List<Order> orders = _context.Orders.Take(5).ToList();

            ViewBag.Customers = customers;
            ViewBag.Products = products;
            ViewBag.Orders = orders;
            return View();
        }

        [HttpPost]
        [Route("/orders/new")]
        public IActionResult NewOrder(Order model)
        {
            if(ModelState.IsValid)
            {
                Customer thisCustomer = _context.Customers.SingleOrDefault(c => c.Name == model.CustomerName);
                Product thisProduct = _context.Products.SingleOrDefault(p => p.Name == model.ProductName);
                Order newOrder = new Order
                {
                    CustomerName = model.CustomerName,
                    ProductName = model.ProductName,
                    Customer = thisCustomer,
                    CustomerId = thisCustomer.Id,
                    Date = DateTime.Now
                };
                if(model.Quantity > thisProduct.Quantity)
                {
                    TempData["QuantityError"] = "You cannot purchase more than the existing stock";
                }
                else 
                {   
                    newOrder.Quantity = model.Quantity;
                    thisProduct.Quantity -= model.Quantity;
                    _context.Add(newOrder);
                    _context.SaveChanges();
                    return RedirectToAction("Dashboard");
                }
            }
            return RedirectToAction("Orders");
        }

        [HttpGet]
        [Route("/products")]
        public IActionResult Products()
        {
            List<Product> products = _context.Products.ToList();

            ViewBag.Products = products;
            return View();
        }

        [HttpPost]
        [Route("/products/new")]
        public IActionResult NewProduct(Product model)
        {
            if (ModelState.IsValid)
            {
                Product newProduct = new Product
                {
                    Name = model.Name,
                    Quantity = model.Quantity,
                    ImageURL = model.ImageURL,
                    Description = model.Description
                };
                _context.Add(newProduct);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return RedirectToAction("Products");
        }

        [HttpGet]
        [Route("/customers")]
        public IActionResult Customers()
        {
            List<Customer> customers = _context.Customers.ToList();

            ViewBag.Customers = customers;
            return View();
        }

        [HttpPost]
        [Route("/customers/new")]
        public IActionResult NewCustomer(Customer model)
        {
            Customer thisCustomer = _context.Customers.SingleOrDefault(c => c.Name == model.Name);
            if (ModelState.IsValid)
            {
                Customer newCustomer = new Customer
                {
                    CreatedAt = DateTime.Now
                };
                if (thisCustomer != null)
                {
                    TempData["ExistingUser"] = "User already exists; please try again";
                }
                else
                {
                    newCustomer.Name = model.Name;
                    _context.Add(newCustomer);
                    _context.SaveChanges();
                    return RedirectToAction("Dashboard");
                }
            }
            return RedirectToAction("Customers");
        }
    }
}