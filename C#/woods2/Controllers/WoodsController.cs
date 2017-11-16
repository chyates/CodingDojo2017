using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using woods2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace woods2.Controllers
{
    public class WoodsController : Controller
    {
        private WoodsContext _context;

        public WoodsController(WoodsContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Trail> trails = _context.Trails.ToList();
            Wrapper model = new Wrapper(trails);
            return View(model);
        }

        [HttpPost]
        [Route("/addTrail")]
        public IActionResult CreateTrail(TrailViewModel model)
        {
            if (ModelState.IsValid)
            {
                Trail newTrail = new Trail
                {
                    TrailName = model.TrailName,
                    Description = model.Description,
                    Length = model.Length,
                    Elevation = model.Elevation,
                    Longitude = model.Longitude,
                    LongDegree = model.LongDegree,
                    Latitude = model.Latitude,
                    LatDegree = model.LatDegree
                };
                _context.Add(newTrail);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        [Route("/newTrail")]
        public IActionResult CreateTrail()
        {
            return View();
        }

        [HttpGet]
        [Route("/trails/{id}")]
        public IActionResult Trail(int id)
        {
            int trailId = id;
            Trail thisTrail = _context.Trails.SingleOrDefault(t => t.TrailId == trailId);
            ViewBag.Trail = thisTrail;
            return View();
        }
    }
}
