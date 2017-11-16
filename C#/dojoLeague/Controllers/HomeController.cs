using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Session;
using dojoLeague.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace dojoLeague.Controllers
{
    public class HomeController : Controller
    {

        private LeagueContext _context;

        public HomeController(LeagueContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Dojo> dojos = _context.Dojos.ToList();
            List<Ninja> ninjas = _context.Ninjas.ToList();

            Wrapper model = new Wrapper(ninjas, dojos);
            return View(model);
        }

        [HttpGet]
        [Route("/dojos/new")]
        public IActionResult NewDojo()
        {
            return View();
        }

        [HttpPost]
        [Route("/addDojo")]
        public IActionResult AddDojo(Dojo model)
        {
            if (ModelState.IsValid)
            {
                Dojo newDojo = new Dojo
                {
                    Name = model.Name,
                    Location = model.Location,
                    AddlInfo = model.AddlInfo
                };
                _context.Add(newDojo);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("NewDojo");
        }

        [HttpGet]
        [Route("/ninjas/new")]
        public IActionResult NewNinja()
        {
            List<Dojo> allDojos = _context.Dojos.ToList();
            ViewBag.Dojos = allDojos;
            return View();
        }

        [HttpPost]
        [Route("/addNinja")]
        public IActionResult AddNinja(Ninja model)
        {
            if (ModelState.IsValid)
            {   

                Ninja newNinja = new Ninja
                {
                    Name = model.Name,
                    Level = model.Level,
                    DojoName = model.DojoName,
                    Description = model.Description
                };
                _context.Add(newNinja);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("NewNinja");
        }

        [HttpGet]
        [Route("/dojos")]
        public IActionResult Dojos()
        {
            List<Dojo> dojos = _context.Dojos.ToList();
            List<Ninja> ninjas = _context.Ninjas.ToList();

            Wrapper model = new Wrapper(ninjas, dojos);
            return View(model);
        }

        [HttpGet]
        [Route("/dojos/{dojoId}")]
        public IActionResult Dojo (int dojoId)
        {
            Dojo thisDojo = _context.Dojos.SingleOrDefault(d => d.Id == (int)dojoId);
            List<Ninja> ninjas = _context.Ninjas.ToList();
            ViewBag.Ninjas = ninjas;
            ViewBag.Dojo = thisDojo;
            return View();
        }

        [HttpGet]
        [Route("/ninjas/{ninjaId}")]
        public IActionResult Ninja (int ninjaId)
        {
            Ninja thisNinja = _context.Ninjas.SingleOrDefault(n => n.Id == (int)ninjaId);
            Dojo currentDojo = _context.Dojos.SingleOrDefault(d => d.Name == thisNinja.DojoName);
            ViewBag.Ninja = thisNinja;
            ViewBag.CurrentDojo = currentDojo;
            return View();
        }

        [HttpGet]
        [Route("/{dojoId}/ninjas/{ninjaId}/update")]
        public IActionResult RecruitNinja(int dojoId, int ninjaId)
        {
            Ninja thisNinja = _context.Ninjas.SingleOrDefault(n => n.Id == (int)ninjaId);
            Dojo thisDojo = _context.Dojos.SingleOrDefault(d => d.Id == (int)dojoId);
            thisNinja.DojoName = thisDojo.Name;
            _context.SaveChanges();
            return RedirectToAction("Dojo");
        }
    }
}
