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
    public ActionResult Create(string name)
    {
      Stylist newStylist = new Stylist(name);
      newStylist.Save();
      List<Stylist> myStylists = Stylist.GetAll();
      return View("Index", myStylists);
    }

    [HttpGet("/stylists/{id}")]
    public ActionResult Show(int stylistId, int clientId)
    {
      Dictionary<string, object> model = new Dictionary <string, object>();
      Stylist newStylist = Stylist.Find(stylistId);
      List<Client> myClients = newStylist.GetClients();
      Client client = Client.Find(clientId);
      model.Add("stylist", newStylist);
      model.Add("clients", myClients);
      model.Add("client", client);
      return View(model);
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
