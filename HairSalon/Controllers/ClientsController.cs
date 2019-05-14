using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {

        [HttpGet("/stylists/{stylistId}/clients")]
    public ActionResult Index(int stylistId)
    {
      Stylist stylist = Stylist.Find(stylistId);
      //get all clients for that stylist
      //create dictionary model for stylist, and clients
      //pass dict into view
      return View(stylist);
    }
    // routes to new client page
    [HttpGet("/stylists/{stylistId}/clients/new")]
    public ActionResult New(int stylistId)
    {
      Stylist stylist = Stylist.Find(stylistId);
      return View(stylist);
    }

    [HttpPost("/stylists/{stylistId}/clients")]
    public ActionResult Create(string clientName, int stylistId)
    {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Stylist selectedStylist = Stylist.Find(stylistId);
        Client newClient = new Client(clientName, stylistId);
        newClient.Save();
        List<Client> myClients = selectedStylist.GetClients();
        model.Add("clients", myClients);
        model.Add("stylist", selectedStylist);
        return View("Index", model);
    }

    // routes to new client's page
    [HttpGet("/stylists/{id}/clients/{clientId}")]
    public ActionResult Show(int stylistId, int clientId)
    {
      Client client = Client.Find(clientId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist stylist = Stylist.Find(stylistId);
      model.Add("client", client);
      model.Add("stylist", stylist);
      return View(model);
    }

  }
}
