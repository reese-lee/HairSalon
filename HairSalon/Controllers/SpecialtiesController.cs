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

    [HttpGet("/specialties/{specialtyId}")]
    public ActionResult Show(int specialtyId)
    {
      // int newSpecialtyId = int.Parse(specialtyId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      Specialty specialty = Specialty.Find(specialtyId);
      List<Stylist> stylistSpecialties = specialty.GetStylists();
      List<Stylist> stylists = Stylist.GetAll();
      model.Add("specialty", specialty);
      model.Add("stylistSpecialties", stylistSpecialties);
      model.Add("stylists", stylists);
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

    [HttpGet("/specialty/delete")]
    public ActionResult DeleteAll()
    {
      Specialty.ClearAll();
      List<Specialty> allSpecialties = Specialty.GetAll();
      return RedirectToAction("Index", allSpecialties);
    }

    [HttpGet("/specialty/{specialtyId}/delete")]
    public ActionResult Destroy(int specialtyId)
    {
      Specialty specialty = Specialty.Find(specialtyId);
      specialty.Delete();
      List<Specialty> allSpecialties = Specialty.GetAll();
      return RedirectToAction("Index", allSpecialties);
    }
  }
}
