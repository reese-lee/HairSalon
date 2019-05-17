using Microsoft.AspNetCore.Mvc;

namespace HairSalon.Controllers
{
   public class SpecialtiesController : Controller
   {

     [HttpGet("/specialties")]
     public ActionResult Index()
     {
       return View();
     }
   }
}
