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

    // works fine
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

    //not working -- not showing proper clientId. showing as 0
    [HttpGet("/stylists/{stylistId}/clients/{clientId}")]
    public ActionResult Show(int stylistId, int clientId)
    {
      // int newClientId = int.Parse(clientId);
      Client client = Client.Find(clientId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist stylist = Stylist.Find(stylistId);
      model.Add("client", client);
      model.Add("stylist", stylist);
      return View(model);
    }

    [HttpGet("/stylists/{stylistId}/clients/{clientId}/edit")]
    public ActionResult Edit(int stylistId, int clientId)
    {
        Client client = Client.Find(clientId);
        Dictionary<string, object> model = new Dictionary<string, object>();
        Stylist stylist = Stylist.Find(stylistId);
        model.Add("stylist", stylist);
        model.Add("client", client);
        return View(model);
    }

    [HttpPost("/stylists/{stylistId}/clients/{clientId}/edit")]
    public ActionResult Update(int stylistId, int clientId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist stylist = Stylist.Find(stylistId);
      Client client = Client.Find(clientId);
      model.Add("stylist", stylist);
      model.Add("client", client);
      return View(model);
    }

    [HttpPost("/stylists/{stylistId}/clients/delete")]
    public ActionResult Delete(int clientId)
    {
      Client client = Client.Find(clientId);
      client.Delete();
      return View();
    }

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
