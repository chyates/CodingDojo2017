using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace csharp_survey.Controllers 
{
    public class SurveyController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("/result")]
        public IActionResult Result(string yourName, string location, string favLang, string addlComm)
        {
            ViewBag.yourName = yourName;
            ViewBag.Location = location;
            ViewBag.favLang = favLang;
            ViewBag.addlComm = addlComm;
            return View();
        }

        [HttpGet]
        [Route("/home")]
        public IActionResult Home()
        {
            return RedirectToAction("Index");
        }
    }
}