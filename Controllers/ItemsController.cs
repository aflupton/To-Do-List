using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
  public class ItemsController : Controller
    {

      [HttpGet("/Items")]
      public ActionResult List()
      {
        List<Item> allItems = Item.GetAll();
        return View("/Items/List", allItems);
      }

      [HttpGet("/Items/AddItem")]
      public ActionResult CreateForm()
      {
        return View("/Items/AddItem");
      }

      [HttpPost("/Categories/CreateItem")]
      public ActionResult CreateItem()
      {
         var type = (Request.Form["item"]);
         var date = (Request.Form["date"]);
         var description = (Request.Form["description"]);
         var importance = (Request.Form["importance"]);
         Item newItem = new Item(type, date, description, importance);
         newItem.Save();
         List<Item> allItems = Item.GetAll();
         return View("/Items/List", allItems);
      }

      // [HttpGet("/List/Details/{id}")]
      // public ActionResult Details(int id)
      // {
      //   Item item = Item.Find(id);
      //   return View("Details", item);
      // }

      [HttpGet("/Items/Delete")]
      public ActionResult Delete()
      {
        List<Item> allItems = Item.GetAll();
        int itemId = int.Parse((Request.Query["id"]));
        allItems.RemoveAt(itemId);
        return View("/Items/List", allItems);
      }

    }
}
