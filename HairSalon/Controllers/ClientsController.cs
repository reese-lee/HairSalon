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

    [HttpPost("/stylists/{stylistId}/clients/new")]
    public ActionResult Create(string clientName, int stylistId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist selectedStylist = Stylist.Find(stylistId);
      Client newClient = new Client(clientName, stylistId);
      newClient.Save();
      List<Client> myClients = selectedStylist.GetClients();
      model.Add("clients", newClient);
      model.Add("stylist", selectedStylist);
      return View("Index", model);
    }

    [HttpGet("/stylists/{stylistId}/clients/{clientId}")]
    public ActionResult Show(int stylistId, int clientId)
    {
      Client client = Client.Find(clientId);
      Stylist stylist = Stylist.Find(stylistId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("clients", client);
      model.Add("stylist", stylist);
      return View(model);
    }

    // [HttpPost("/stylists/{stylistId}/clients/delete")]
    // public ActionResult Delete(int clientId)
    // {
    //   Client client = Client.Find(clientId);
    //   client.Delete();
    //   return View();
    // }
    // routes to new client's page
    // [HttpGet("/stylists/{stylistId}/clients/{clientId}")]
    // public ActionResult Show(int stylistId, int clientId)
    // {
    //   Client client = Client.Find(clientId);
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   Stylist stylist = Stylist.Find(stylistId);
    //   model.Add("client", client);
    //   model.Add("stylist", stylist);
    //   return View(model);
    // }

  }
}
