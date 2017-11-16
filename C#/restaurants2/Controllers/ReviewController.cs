using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Session;
using restaurants2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace restaurants2.Controllers
{
    public class ReviewController : Controller
    {

        RestaurantContext _context;

        public ReviewController(RestaurantContext context)
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
        [Route("/addReview")]
        public IActionResult AddReview(Review model)
        {
            if (ModelState.IsValid)
            {
                Review newReview = new Review
                {
                    Reviewer = model.Reviewer,
                    Restaurant = model.Restaurant,
                    ReviewContent = model.ReviewContent,
                    Rating = model.Rating
                };
                if (model.VisitDate > DateTime.Now)
                {
                    TempData["InvalidDate"] = "Your visit date must fall before the current date.";
                }
                else 
                {
                    newReview.VisitDate = model.VisitDate;
                    _context.Add(newReview);
                    _context.SaveChanges();
                    return RedirectToAction("Reviews");
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("/reviews")]
        public IActionResult Reviews()
        {
            List<Review> allReviews = _context.Reviews.OrderBy(r => r.VisitDate).ToList();
            ViewBag.Reviews = allReviews;
            return View();
        }
    }
}
