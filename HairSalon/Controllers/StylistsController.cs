using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace Stylists.Controllers
{
  public class StylistsController : Controller
  {

    // [HttpGet("/stylists")]
    // public ActionResult Index()
    // {
    //   List<Stylist> allStylists = Stylists.GetAll();
    //   return View(allStylists);
    // }
    //
    // [HttpGet("/stylists/new")]
    // public ActionResult New()
    // {
    //   return View();
    // }
    //
    //
    // [HttpPost("/stylists")]
    // public ActionResult Create(string type)
    // {
    //   Stylists myStylists = new Stylists(type);
    //   myStylists.Save();
    //   return RedirectToAction("Index");
    // }
    //
    // [HttpGet("/stylists/{id}/restaurant/new")]
    // public ActionResult Show()
    // {
    //   // Restaurant newRestaurant = new Restaurant(name, address, phoneNumber, stylistsId);
    //   List<Stylists> allStylists = Stylists.GetAll();
    //   return View();
    // }

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
