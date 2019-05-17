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

     [HttpPost("/specialties")]
     public ActionResult Create(string specialtyName)
     {
       Specialty newSpecialty = new Specialty(specialtyName);
       List<Specialty> specialties = Specialty.Add();
       return RedirectToAction("Index");
     }
   }
}
