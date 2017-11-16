using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Session;
using csharpBoiler.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace csharpBoiler.Controllers
{
    public class HomeController : Controller
    {
        private BoilerContext _context;

        private bool checkLogStatus()
        {
            int? currentUserId = HttpContext.Session.GetInt32("currentUserId");
            if (currentUserId == null)
            {
                TempData["UserError"] = "You must be logged in!";
                return false;
            }
            else 
            {
                return true;
            }
        }
        private string hashPW(User user, string password)
        {
            PasswordHasher<User> hasher = new PasswordHasher<User>();
            user.Password = hasher.HashPassword(user, password);
            return user.Password;
        }
        public HomeController(BoilerContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("")]
        public IActionResult Index(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User newUser = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Created_At = DateTime.Now,
                    Updated_At = DateTime.Now
                };
                newUser.Password = hashPW(newUser, model.Password);
                _context.Add(newUser);
                _context.SaveChanges();
                
                HttpContext.Session.SetInt32("currentUserId", newUser.UserId);
                HttpContext.Session.SetString("currentFirstName", newUser.FirstName);
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [Route("/login")]
        public IActionResult Login(string email, string password)
        {
            User logUser = _context.Users.SingleOrDefault(user => user.Email == email);
            if (logUser == null)
            {
                TempData["EmailError"] = "Invalid email!";
                return RedirectToAction("Index");
            }
            else
            {
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                if (hasher.VerifyHashedPassword(logUser, logUser.Password, password) != 0)
                {
                    HttpContext.Session.SetInt32("currentUserId", logUser.UserId);
                    HttpContext.Session.SetString("currentUserEmail", logUser.Email);
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    TempData["PasswordError"] = "Invalid password";
                    return RedirectToAction("Index");
                }
            }
        }

        [HttpGet]
        [Route("/dashboard")]
        public IActionResult Dashboard()
        {
            int? currentUserId = HttpContext.Session.GetInt32("currentUserId");
            if (checkLogStatus() == false)
            {
                return RedirectToAction("Index");
            }
            else
            {
                User currentUser = _context.Users.SingleOrDefault(u => u.UserId == (int)currentUserId);

                // **MODIFY FOLLOWING LINES TO REFLECT PROJECT MODELS**

                List<User> users = _context.Users.ToList();
                
                return View();
            }
        }
    }
}
