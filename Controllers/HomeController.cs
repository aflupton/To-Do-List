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
        List<ToDo> allItems = ToDo.GetAll();
        return View("Inventory", allItems);
      }

      [HttpGet("/AddItem")]
      public ActionResult AddItem()
      {
        return View("AddItem");
      }

      [HttpPost("/CreateItem")]
      public ActionResult CreateItem()
      {
         var item = (Request.Form["item"]);
         var date = (Request.Form["date"]);
         var description = (Request.Form["description"]);
         var importance = (Request.Form["importance"]);
         ToDo newItem = new ToDo(item, date, description, importance);
         newItem.Save();
         List<ToDo> allItems = ToDo.GetAll();
         return View("List", allItems);
      }



      [HttpGet("/delete")]
      public ActionResult Delete()
      {
        List<ToDo> allItems = ToDo.GetAll();
        int itemId = int.Parse((Request.Query["id"]));
        allItems.RemoveAt(itemId);
        return View("Inventory", allItems);
      }

    }

}
