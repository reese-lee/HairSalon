using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace Stylists.Controllers
{
  public class StylistsController : Controller
  {

    [HttpGet("/stylists")]
    public ActionResult Index()
    {
      List<Stylist> allStylists = Stylist.GetAll();
      return View(allStylists);
    }

    [HttpGet("/stylists/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/stylists")]
    public ActionResult Create(string name, string specialty)
    {
      Stylist myStylists = new Stylist(name, specialty);
      myStylists.Save();
      return RedirectToAction("Index");
    }

    [HttpGet("/stylists/{id}")]
    public ActionResult Show(string name, string specialty, int id)
    {
      Stylist newStylist = new Stylist(name, specialty, id);
      // List<Stylist> allStylists = Stylist.GetAll();
      return View();
    }

    // [HttpPost("/stylists/{id}/restaurant")]
    // public ActionResult New(string name, string address, string phoneNumber, int stylistsId)
    // {
    //   Restaurant myRestaurant = new Restaurant(name, address, phoneNumber, stylistsId);
    //   return RedirectToAction("Index");
    // }

    // [HttpGet("/animals/SortByType")]
    // public ActionResult SortByType()
    // {
    //   // Animal newAnimal = new Animal();
    //   List<Animal> allSortedAnimals = Animal.SortByType();
    //   return View(allSortedAnimals);
    // }
  }
}
