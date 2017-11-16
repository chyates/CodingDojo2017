using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using restaurants.Models;
using System.Linq;

namespace restaurants.Controllers
{
    public class ReviewController : Controller
    {
        private ReviewContext _context;

        public ReviewController(ReviewContext context)
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
        [Route("/add")]
        public IActionResult Add()
        {
            return RedirectToAction("Reviews");
        }

        [HttpGet]
        [Route("/reviews")]
        public IActionResult Reviews()
        {
            List<Review> allReviews = _context.Reviews.ToList();
            ViewBag.
            return View();
        }
    }
}
