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

    [HttpPost("/stylists/{id}/clients")]
    public ActionResult Create(string name, int stylistId, int id)
    {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Stylist selectedStylist = Stylist.Find(stylistId);
        Client newClient = new Client(name, stylistId, id);
        newClient.Save();
        List<Client> myClients = selectedStylist.GetClients();
        model.Add("clients", myClients);
        model.Add("stylists", selectedStylist);
        return View("Show", model);
    }

    // [HttpGet("/stylists/{stylistId}/clients/new")]
    // public ActionResult New(string name, int stylistId, int id)
    // {
    //   Client myClient = new Client(name, stylistId, id);
    //   return RedirectToAction();
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
