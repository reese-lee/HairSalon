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
       return View();
     }

     [HttpPost("/specialties")]
     public ActionResult Create(string specialtyName)
     {
       Dictionary<string, object> model = new Dictionary <string, object>();
       Specialty newSpecialty = new Specialty(specialtyName);
       List<Specialty> specialties = Specialty.GetAll();
       model.Add(newSpecialty);
       return RedirectToAction("Index", model);
     }
   }
}
