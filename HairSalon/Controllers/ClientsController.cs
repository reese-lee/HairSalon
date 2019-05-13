using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {
    // routes to new client page
    [HttpGet("/stylists/{stylistId}/clients/new")]
    public ActionResult New(string name, int stylistId, int id)
    {
      Stylist selectedStylist = Stylist.Find(stylistId);
      Client client = new Client(name, stylistId, id);
      client.Save();
      Client.Find(stylistId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("clients", client);
      model.Add("stylists", selectedStylist);
      return View("Show", model);
    }

    // routes to new client's page
    [HttpPost("/stylists/{id}/clients/{clientId}")]
    public ActionResult Show(string name, int stylistId, int id)
    {
      // Stylist selectedStylist = Stylist.Find(stylistId);
      // Client client = new Client(name, stylistId, id);
      // client.Save();
      // Dictionary<string, object> model = new Dictionary<string, object>();
      // model.Add("clients", client);
      // model.Add("stylists", selectedStylist);
      return View();
    }

    // [HttpGet("/stylists/{id}/clients/{clientId}")]
    // public ActionResult New(string name, int stylistId, int id)
    // {
    //
    //   Stylist selectedStylist = Stylist.Find(stylistId);
    //   Client client = new Client(name, stylistId, id);
    //   client.Save();
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   model.Add("clients", client);
    //   model.Add("stylists", selectedStylist);
    //   return View(model);
    // }


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
