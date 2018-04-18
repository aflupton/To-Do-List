using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;

namespace ToDoList.Controllers
{
  public class HomeController : Controller
    {
      [HttpGet("/")]
      public ActionResult Index()
      {
        return View("Index");
      }

      [HttpGet("/List")]
      public ActionResult Inventory()
      {
        List<ToDoVariables> allItems = ToDoVariables.GetAll();
        return View("List", allItems);
      }

      [HttpGet("/AddItem")]
      public ActionResult AddItem()
      {
        return View("AddItem");
      }

      [HttpPost("/createitem")]
      public ActionResult CreateItem()
      {
         var type = (Request.Form["item"]);
         var date = (Request.Form["date"]);
         var description = (Request.Form["description"]);
         var importance = (Request.Form["importance"]);
         ToDoVariables newItem = new ToDoVariables(type, date, description, importance);
         newItem.Save();
         List<ToDoVariables> allItems = ToDoVariables.GetAll();
         return View("List", allItems);
      }

      [HttpGet("/delete")]
      public ActionResult Delete()
      {
        List<ToDoVariables> allItems = ToDoVariables.GetAll();
        int itemId = int.Parse((Request.Query["id"]));
        allItems.RemoveAt(itemId);
        return View("List", allItems);
      }

    }

}
