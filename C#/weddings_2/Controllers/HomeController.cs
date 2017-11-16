using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Session;
using weddings_2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace weddings_2.Controllers
{
    public class HomeController : Controller
    {
        private WeddingContext context;

        public HomeController(WeddingContext _context)
        {
            context = _context;
        }
        // GET: /Home/
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
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                newUser.Password = hasher.HashPassword(newUser, model.Password);
                context.Add(newUser);
                context.SaveChanges();
                HttpContext.Session.SetInt32("currentUserId", newUser.UserId);
                HttpContext.Session.SetString("currentemail", newUser.FirstName);
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
            User loggedInUser = context.Users.SingleOrDefault(user => user.Email == email);
            if (loggedInUser == null)
            {
                TempData["EmailError"] = "Invalid email";
                return RedirectToAction("Index");
            }
            else
            {
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                if (hasher.VerifyHashedPassword(loggedInUser, loggedInUser.Password, password) != 0)
                {
                    HttpContext.Session.SetInt32("currentUserId", loggedInUser.UserId);
                    HttpContext.Session.SetString("currentEmail", loggedInUser.FirstName);
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
            int? userId = HttpContext.Session.GetInt32("currentUserId");
            if (userId == null)
            {
                TempData["UserError"] = "You must be logged in";
                return RedirectToAction("Index");
            }
            else
            {
                User currentUser = context.Users.SingleOrDefault(u => u.UserId == (int)userId);
                List<Guest> guests = context.Guests.Include(g => g.UserId).Include(g => g.WeddingId).ToList();
                List<Wedding> weddings = context.Weddings.Include(g => g.WeddingId).ToList();

                Wrapper model = new Wrapper(weddings, guests);
                return View();
            }
        }

        [HttpGet]
        [Route("/addWedding")]
        public IActionResult AddWedding(){
            return View();
        }

        [HttpPost]
        [Route("/addWedding")]
        public IActionResult AddWedding(WeddingViewModel model)
        {
            int? userId = HttpContext.Session.GetInt32("currentUserId");
            if (userId == null)
            {
                TempData["UserError"] = "You must be logged in";
                return RedirectToAction("Index");
            }
            else
            {
                User currentUser = context.Users.SingleOrDefault(u => u.UserId == (int)userId);
                if(ModelState.IsValid)
                {
                    if(model.Date.Date < DateTime.Today)
                    {
                        TempData["InvalidDate"] = "Your end date must fall after today";
                        return View();
                    }
                    else
                    {
                    Wedding newWedding = new Wedding {
                        WedderOne = model.WedderOne,
                        WedderTwo = model.WedderTwo,
                        Address = model.Address,
                        Date = model.Date
                    };
                    context.Add(newWedding);
                    context.SaveChanges();
                    return RedirectToAction("Dashboard");
                    }
                    
                }
            }
            if(model.Date.Date < DateTime.Today)
            {
                TempData["InvalidDate"] = "Your end date must fall after today";
            }
            return View();
        }
    }
}