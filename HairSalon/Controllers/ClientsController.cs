using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {

    [HttpGet("/clients/")]
    public ActionResult Index()
    {
      // Animal newAnimal = new Animal();
      List<Client> allClients = Client.GetAll();
      return View(allClients);
    }

    // [HttpGet("/clients/{id}/new")]
    // public ActionResult New(int id)
    // {
    //   return View(Stylist.Find(id));
    // }


    // [HttpPost("/clients")]
    // public ActionResult Create(string name, string address, string phoneNumber, int clientId)
    // {
    //   Client myClient = new Client(name, address, phoneNumber, clientId);
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
