using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ajax_notes.DbConnection;

namespace ajax_notes.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            string queryString = "SELECT * FROM notes ORDER BY id DESC";
            List<Dictionary<string, object>> results = DbConnector.Query(queryString);
            ViewBag.notes = results;
            return View();
        }

        [HttpPost]
        [Route("/add_note")]
        public string AddNote(string title)
        {
            string queryString = $"INSERT INTO notes (title, created_at, updated_at) VALUES ('{title}', NOW(), NOW())";
            DbConnector.Execute(queryString);
            return "okay";
        }
            

        [HttpPost]
        [Route("/update_note")]
        public string UpdateNote(string content, string id)
        {
            string queryString = $"UPDATE notes SET (content, updated_at) = ('{content}', NOW()) WHERE id={id}";
            DbConnector.Execute(queryString);
            return "okay";
        }

    }
}
