using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {
    [HttpPost("/stylists/{id}/clients/new")]
    public ActionResult New(int stylistId)
    {
      Stylist newStylist = Stylist.Find(stylistId);
      // Client myClient = new Client(name, stylistId, id);
      return View(newStylist);
    }

    [HttpGet("/stylists/{stylistId}/clients/{clientId}")]
    public ActionResult New(int stylistId, int clientId)
    {
      Client client = Client.Find(clientId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist stylist = Stylist.Find(stylistId);
      model.Add("client", client);
      model.Add("stylist", stylist);
      return View(model);
    }

    // [HttpGet("/clients/{id}/new")]
    // public ActionResult New(int id)
    // {
    //   return View(Stylist.Find(id));
    // }


    // [HttpPost("/clients")]
    // public ActionResult Create(string name, int stylistId, int id)
    // {
    //   Client myClient = new Client(name, stylistId, id);
    //   myClient.Save();
    //   return RedirectToAction("Index");
    // }

    // [HttpGet("/client/{clientId}/clients/{clientsId}")]
    // public ActionResult Show(int clientId, int clientsId)
    // {
    //     Client clients = Client.Find(clientsId);
    //     Dictionary<string, object> model = new Dictionary<string, object>();
    //     Client client = Client.Find(clientId);
    //     model.Add("clients", clients);
    //     model.Add("client", client);
    //     return View(model);
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
