using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using csharpLogin2.Models;


namespace csharpLogin2.Controllers
{
    public class UserController : Controller
    {
        private readonly DbConnector _dbConnector;

        public UserController(DbConnector connect)
        {
            _dbConnector = connect;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            // List<Dictionary<string, object>> AllUsers = _dbConnector.Query("SELECT * FROM users");
            // Other code

            return View();
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(string firstName, string lastName, string email, string password)
        {
            User newUser = new User 
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };

            if (TryValidateModel(newUser) == false)
            {
                ViewBag.ModelFields = ModelState.Values;
                return RedirectToAction("Index");
            }

                string query = $"INSERT INTO users (first_name, last_name, email, password, created_at, updated_at) VALUES ('{firstName}', '{lastName}', '{email}', '{password}', NOW(), NOW()); SELECT LAST_INSERT_ID() as id";
                _dbConnector.Execute(query);
                HttpContext.Session.SetInt32("id", Convert.ToInt32(_dbConnector.Query(query)[0]["id"]));
                RedirectToAction("Success");
            }
        }

        [HttpPost]
        [Route("login")]
        public  Login(string email, string password)
        {
            List<Dictionary<string, object>> logUser = _dbConnector.Query($"SELECT id, password FROM users WHERE email = '{email}'");

            // if()
            // {

            //     HttpContext.Session.SetInt32("id", (int)logUser[0]["id"]);
            //     return RedirectToAction("Success");
            // }

            return View("Index");
        }

        [HttpGet]
        [Route("success")]
        public IActionResult Success()
        {
            return View();
        }
    }
