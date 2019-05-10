using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Controllers
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
    public ActionResult Create(string name, string specialty, int id)
    {
      Stylist newStylist = new Stylist(name, specialty, id);
      newStylist.Save();
      List<Stylist> myStylists = Stylist.GetAll();
      return View("Index", myStylists);
    }

    [HttpGet("/stylists/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary <string, object>();
      Stylist newStylist = Stylist.Find(id);
      List<Client> myClients = newStylist.GetClients();
      model.Add("stylists", newStylist);
      model.Add("clients", myClients);
      return View(model);
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
