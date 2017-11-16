using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Session;
using wedding_planner.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace wedding_planner.Controllers
{
    public class HomeController : Controller
    {
        MyAppContext _context;

        public HomeController(MyAppContext context)
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
                _context.Add(newUser);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("currentUserId", newUser.UserId);
                HttpContext.Session.SetString("currentUserName", newUser.FirstName);
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
            User loggedInUser = _context.Users.SingleOrDefault(user => user.Email == email);
            if (loggedInUser == null)
            {
                TempData["UsernameError"] = "Invalid email";
                return RedirectToAction("Index");
            }
            else
            {
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                if (hasher.VerifyHashedPassword(loggedInUser, loggedInUser.Password, password) != 0)
                {
                    HttpContext.Session.SetInt32("currentUserId", loggedInUser.UserId);
                    HttpContext.Session.SetString("currentUserName", loggedInUser.FirstName);
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
            int? userID = HttpContext.Session.GetInt32("currentUserId");
            if (userID == null)
            {
                TempData["UserError"] = "You must be logged in";
                return RedirectToAction("Index");
            }
            else
            {
                User currentUser = _context.Users.SingleOrDefault(u => u.UserId == (int)userID);
                // List<User> users = _context.Users.Include(u => u.Weddings).ThenInclude(g => g.Guests).ToList();
                List<Guest> allGuests = _context.Guests.Include(g => g.User).Include(g => g.Wedding).ToList();
                List<Wedding> allWeddings = _context.Weddings.OrderBy(w => w.Date).ToList();
                ViewBag.Weddings = allWeddings;
                ViewBag.Guests = allGuests;
                return View();
            }
        }

        [HttpGet]
        [Route("/addWedding")]
        public IActionResult AddWedding()
        {
            return View();
        }

        [HttpGet]
        [Route("/weddings/{id}")]
        public IActionResult Wedding(int id)
        {
            return View();
        }

        [HttpGet]
        [Route("/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("/add")]
        public IActionResult Add(string bride, string groom, DateTime date)
        {
            Wedding thisWedding = new Wedding();
            thisWedding.Bride = bride;
            thisWedding.Groom = groom;
            thisWedding.Date = date;
            _context.Add(thisWedding);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }
    }
}
