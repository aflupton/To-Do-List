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
        return View(allItems);
      }

      [HttpGet("/Items/AddItem")]
      public ActionResult CreateForm()
      {
        return View();
      }

      [HttpGet("/Categories/{categoryId}/Items/New")]
      public ActionResult CreateForm(int categoryId)
        {
          Dictionary<string, object> model = new Dictionary<string, object>();
          Category category = Category.Find(categoryId);
          return View(category);
        }

      [HttpGet("/Categories/{categoryId}/Items/{itemId}")]
      public ActionResult Details(int categoryId, int itemId)
      {
        Item item = Item.Find(itemId);
        Dictionary<string, object> model = new Dictionary<string, object>();
        Category category = Category.Find(categoryId);
        model.Add("item", item);
        model.Add("category", category);
        return View(item);
      }
      
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
