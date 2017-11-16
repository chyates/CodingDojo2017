using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using csharp_form.Models;

namespace csharp_form.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(){

        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("/process")]
        public IActionResult Process(string firstName, string lastName, int age, string email, string password)
        {
            User newUser = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                Email = email,
                Password = password
            };
            
            if (TryValidateModel(newUser) == false)
            {
                ViewBag.ModelFields = ModelState.Values;
                return View();
            }

            else
            {
                return RedirectToAction("Success");
            }
        }

        [HttpGet]
        [Route("/success")]
        public IActionResult Success()
        {
            return View();
        }
    }
}
