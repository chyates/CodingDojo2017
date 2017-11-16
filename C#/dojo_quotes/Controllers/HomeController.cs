using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;

namespace dojo_quotes.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("/create")]
        public IActionResult CreateQuote(string yourName, string content)
        {
            string query = $"INSERT INTO quotes (content, author, created_at, updated_at) VALUES ('{content}', '{yourName}', NOW(), NOW())";
            DbConnector.Execute(query);
            return RedirectToAction("Quotes");
        }

        [HttpGet]
        [Route("/quotes")]
        public IActionResult Quotes()
        {
            string query = "SELECT * FROM quotes";
            var quotes = DbConnector.Query(query);
            ViewBag.Quotes = quotes;
            return View();
        }
    }
}
