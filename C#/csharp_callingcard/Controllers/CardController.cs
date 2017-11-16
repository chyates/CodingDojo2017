using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace csharp_callingcard.Controllers
{
    public class CardController : Controller
    {
        // A GET method
        [HttpGet]
        [Route("/{first_name}/{last_name}/{age}/{fav_color}")]
        public JsonResult DisplayCard(string first_name, string last_name, string age, string fav_color)
        {
            var AnonObject = new {
                firstName = first_name,
                lastName = last_name,
                Age = age,
                favColor = fav_color
            };

            return Json(AnonObject);
        }
    }
}