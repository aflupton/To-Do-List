using Microsoft.AspNetCore.Mvc;
using CarDealership.Models;
using System.Collections.Generic;

namespace CarDealership.Controllers
{
  public class HomeController : Controller
    {
      [Route("/")]
      public ActionResult Index()
      {
        return View("Index");
      }

      [Route("/inventory")]
      public ActionResult Inventory()
      {
        List<CarVariables> allItems = CarVariables.GetAll();
        return View("Inventory", allItems);
      }

      [Route("/create")]
      public ActionResult Create()
      {
        return View("Create");
      }

      [Route("/createcar")]
      public ActionResult CreateCar()
      {
         var make = (Request.Form["make"]);
         var model = (Request.Form["model"]);
         var year = (Request.Form["year"]);
         var price = (Request.Form["price"]);
         CarVariables newCar = new CarVariables(make, model, year, price);
         newCar.Save();
         List<CarVariables> allItems = CarVariables.GetAll();
         return View("Inventory", allItems);
      }

      // [Route("/update")]
      // public ActionResult Update()
      // {
      //   var make = (Request.Query["make"]);
      //   var model = (Request.Query["model"]);
      //   var year = (Request.Query["year"]);
      //   var price = (Request.Query["price"]);
      //   CarVariables newCar = new CarVariables(make, model, year, price);
      //   newCar.Save();
      //   return View("Inventory", newCar);
      // }

      [HttpGet("/delete")]
      public ActionResult Delete()
      {
        List<CarVariables> allItems = CarVariables.GetAll();
        int carId = int.Parse((Request.Query["id"]));
        allItems.RemoveAt(carId);
        return View("Inventory", allItems);
      }

    }

}
