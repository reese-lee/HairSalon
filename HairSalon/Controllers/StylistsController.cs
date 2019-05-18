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
    public ActionResult Create(string name, int id)
    {
      Stylist newStylist = new Stylist(name, id);
      newStylist.Save();
      List<Stylist> myStylists = Stylist.GetAll();
      return View("Index", myStylists);
    }

    [HttpGet("/stylists/{id}")]
    public ActionResult Show(int id, int clientId)
    {
      Dictionary<string, object> model = new Dictionary <string, object>();
      Stylist newStylist = Stylist.Find(id);
      List<Client> myClients = newStylist.GetClients();
      Client client = Client.Find(clientId);
      model.Add("stylist", newStylist);
      model.Add("clients", myClients);
      model.Add("client", client);
      return View(model);
    }

  }
}
