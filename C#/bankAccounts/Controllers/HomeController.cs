using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Session;
using bankAccounts.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace bankAccounts.Controllers
{
    public class HomeController : Controller
    {
        private BankContext _context;

        public HomeController(BankContext context)
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
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                newUser.Password = hasher.HashPassword(newUser, model.Password);
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
            int? userId = HttpContext.Session.GetInt32("currentUserId");
            if (userId == null)
            {
                TempData["UserError"] = "You must be logged in!";
                return RedirectToAction("Index");
            }
            else
            {
                User currentUser = _context.Users.SingleOrDefault(u => u.UserId == (int)userId);
                List<User> users = _context.Users.ToList();
                List<Account> accounts = _context.Accounts.Include(a => a.Transactions).ToList();
                Account thisAccount = _context.Accounts.SingleOrDefault(a => a.HolderId == userId);
                List<Transaction> transactions = _context.Transactions.ToList();

                ViewBag.User = currentUser;
                ViewBag.Account = thisAccount;
                Wrapper model = new Wrapper(users, transactions, accounts);
                return View(model);
            }
        }

        [HttpPost]
        [Route("/withdraw")]
        public IActionResult Withdraw(Transaction model)
        {
            int? userId = HttpContext.Session.GetInt32("currentUserId");
            if (userId == null)
            {
                TempData["UserError"] = "You must be logged in!";
                return RedirectToAction("Index");
            }
            else
            {
                Account thisAccount = _context.Accounts.SingleOrDefault(a => a.HolderId == (int)userId);
                if (ModelState.IsValid)
                {
                    Transaction newTransaction = new Transaction
                    {
                        AccountId = thisAccount.Id,
                        Amount = model.Amount,
                        Type = "withdrawal",
                        Date = DateTime.Now,
                    };
                    if (model.Amount > thisAccount.Balance)
                    {
                        TempData["WithdrawError"] = "You cannot withdraw more than you have in your balance";
                    }
                    else
                    {
                        thisAccount.Balance -= model.Amount;
                        _context.Add(newTransaction);
                        _context.SaveChanges();
                        return RedirectToAction("Dashboard");
                    }
                }
                return RedirectToAction("Dashboard");
            }
        }

        [HttpPost]
        [Route("/deposit")]
        public IActionResult Deposit(Transaction model)
        {
            int? userId = HttpContext.Session.GetInt32("currentUserId");
            if (userId == null)
            {
                TempData["UserError"] = "You must be logged in!";
                return RedirectToAction("Index");
            }
            else
            {
                Account thisAccount = _context.Accounts.SingleOrDefault(a => a.HolderId == (int)userId);
                if (ModelState.IsValid)
                {
                    Transaction newTransaction = new Transaction
                    {
                        AccountId = thisAccount.Id,
                        Amount = model.Amount,
                        Type = "deposit",
                        Date = DateTime.Now,
                    };
                    thisAccount.Balance += model.Amount;
                    _context.Add(newTransaction);
                    _context.SaveChanges();
                    return RedirectToAction("Dashboard");
                }
                return RedirectToAction("Dashboard");
            }
        }
    }
}
