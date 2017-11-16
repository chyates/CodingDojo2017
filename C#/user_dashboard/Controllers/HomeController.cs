using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Session;
using user_dashboard.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace user_dashboard.Controllers
{
    public class HomeController : Controller
    {
        DashboardContext _context;
        public HomeController(DashboardContext context)
        {
            _context = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/register")]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [Route("/register")]
        public IActionResult Register(RegisterViewModel model)
        {
            List<User> users = _context.Users.ToList();
            string newUserLevel = "";
            if (ModelState.IsValid)
            {
                if (users == null)
                {
                    newUserLevel = "admin";
                }
                else {
                    newUserLevel = "user";
                }
                User newUser = new User{
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Created_At = DateTime.Now,
                    Updated_At = DateTime.Now,
                    UserLevel = newUserLevel
                };
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                newUser.Password = hasher.HashPassword(newUser, model.Password);
                _context.Add(newUser);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("currentUserID", newUser.UserId);
                return RedirectToAction("Dashboard");
            }
            else{
                return View(model);
            }
        }
        [HttpGet]
        [Route("/login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("/login")]
        public IActionResult Login (string Email, string Password)
        {
            User loggedInUser = _context.Users.SingleOrDefault(user => user.Email == Email);
            List<string> errors = new List<string>();
            if (loggedInUser == null)
            {
                errors.Add("Invalid email!");
                ViewBag.Errors = errors;
                return View("Login");
            }
            else{
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                if (hasher.VerifyHashedPassword(loggedInUser, loggedInUser.Password, Password) !=0)
                {
                    HttpContext.Session.SetInt32("currentUserID", loggedInUser.UserId);
                    return RedirectToAction("Dashboard");
                }
                else 
                {
                    errors.Add("Invalid password!");
                    ViewBag.Errors = errors;
                    return View("Login");
                }
            }
        }
    }
}
