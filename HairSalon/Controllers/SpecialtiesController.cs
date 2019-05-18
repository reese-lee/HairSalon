using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace HairSalon.Models
{
   public class SpecialtiesController : Controller
   {

     [HttpGet("/specialties")]
     public ActionResult Index()
     {
       List<Specialty> allSpecialties = Specialty.GetAll();
       return View(allSpecialties);
     }

     [HttpPost("/specialties")]
     public ActionResult Create(string type)
     {
       Specialty newSpecialty = new Specialty(type);
       newSpecialty.Save();
       List<Specialty> specialties = Specialty.GetAll();
       return View("Index", specialties);
     }

     [HttpGet("/specialties/{id}")]
      public ActionResult Show(int id)
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Specialty thisSpecialty = Specialty.Find(id);
        List<Stylist> stylistSpecialties = thisSpecialty.GetStylists();
        List<Stylist> allStylists = Stylist.GetAll();
        model.Add("specialty", thisSpecialty);
        model.Add("stylistSpecialties", stylistSpecialties);
        model.Add("allStylists", allStylists);
        return View(model);
      }

     //  [HttpPost("/specialties/{specialtyId}/stylists/new")]
     //  public ActionResult AddStylist(int specialtyId, int stylistId)
     //  {
     //    Specialty specialty = Specialty.Find(specialtyId);
     //    Stylist stylist = Stylist.Find(stylistId);
     //    specialty.AddStylist(stylist);
     //    return RedirectToAction("Show",  new { id = specialtyId });
     //  }
   }
}
