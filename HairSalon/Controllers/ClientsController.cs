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
    public ActionResult New(int stylistId)
    {

      Stylist stylist = Stylist.Find(stylistId);
      return View(stylist);
    }

    // [HttpPost("/stylists/{stylistId}/clients")]
    // public ActionResult Create(string name, int stylistId, int id)
    // {
    //     Dictionary<string, object> model = new Dictionary<string, object>();
    //     Stylist selectedStylist = Stylist.Find(stylistId);
    //     Client newClient = new Client(name, stylistId, id);
    //     newClient.Save();
    //     List<Client> myClients = selectedStylist.GetClients();
    //     model.Add("clients", myClients);
    //     model.Add("stylists", selectedStylist);
    //     return View("Show", model);
    // }

    // routes to new client's page
    [HttpGet("/stylists/{id}/clients/{clientId}")]
    public ActionResult Show(int id, int clientId)
    {
      Client client = Client.Find(clientId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist stylist = Stylist.Find(id);
      model.Add("clients", client);
      model.Add("stylists", stylist);
      return View(model);
    }

  }
}
