using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic; 
using System.Diagnostics;
using System;
using Newtonsoft.Json;
using System.Linq;
 
namespace WebDemo.Controllers
{

    public class HomeController : Controller
    {
        private Random rnd = new Random();
        private const string _theLeague = "TheLeague";
        
        // Default controller action
        // [HttpGetAttribute]
        // public string Index()
        // {
        //     return "Hello World!";
        // }        


        // Replaced by:
        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("/createTeam")]
        public IActionResult processForm(string city, string mascot, byte wins, byte losses)
        {
            // Create a new BaseballTeam from the data passed in...
            BaseballTeam newTeam = new BaseballTeam(city, mascot, wins, losses);

            // Get the existing league out of session...
            string theLeague = HttpContext.Session.GetString(_theLeague);
            List<BaseballTeam> leagueList;

            if(theLeague != null)
            {
                // DESerialize the league back into a list of baseball teams...
                leagueList = JsonConvert.DeserializeObject<List<BaseballTeam>>((string)theLeague);
            }
            else
            {
                leagueList = new List<BaseballTeam>();
            }
            
            // Add the new team to the league...
            leagueList.Add(newTeam);
            
            // Order the team by wins...
            leagueList = leagueList.OrderByDescending(x => x.Wins).ToList();

            // re Serialize the league and put it back in session...
            string strLeague = JsonConvert.SerializeObject(leagueList);
            HttpContext.Session.SetString(_theLeague, strLeague);

            // Put the league in its current state into TempData in order to send to our template.
            TempData[_theLeague] = strLeague;
            
            // We can either redirect to a function:
            // return RedirectToAction("Index");
            // or redirect to a route:
            return RedirectToRoute("/");
        }
        
        [Route("/reset")]
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}