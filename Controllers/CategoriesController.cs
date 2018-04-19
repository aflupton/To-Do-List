using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
  public class CategoriesController : Controller
    {
      [HttpGet("/Categories")]
      public ActionResult Index()
      {
        List<Category> allCategories = Category.GetAll();
        return View("/Categories/Index", allCategories);
      }

      // [HttpGet("/Categories/New")]
      // public ActionResult List()
      // {
      //
      //   return View();
      // }

      [HttpPost("/Categories/AddCategory")]
      public ActionResult CreateForm()
      {
        return View("/Categories/Create");
      }

      [HttpPost("/Categories")]
      public ActionResult CreateCategory()
      {
        Category newCategory = new Category(Request.Form["category-name"]);
        newCategory.Save();
        List<Category> allCategories = Category.GetAll();
        return View("Index", allCategories);
      }

      [HttpGet("/Categories/{id}")]
      public ActionResult Details(int id)
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Category selectedCategory = Category.Find(id);
        List<Item> categoryItems = selectedCategory.GetItems();
        model.Add("Category", selectedCategory);
        model.Add("Items", categoryItems);
        return View(model);
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
        model.Add("Item", item);
        model.Add("Category", category);
        return View(item);
      }

      [HttpPost("/Items")]
      public ActionResult CreateItem()
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Category foundCategory = Category.Find(Int32.Parse(Request.Form("category-id")));
        string itemDescription = Request.Form("item-description");
        Item newItem = new Item(itemDescription);
        foundCategory.AddItem(newItem);
        List<Item> categoryItems = foundCategory.GetItems();
        model.Add("Items", categoryItems);
        model.Add("Category", foundCategory);
        return View("Details", model);
      }

    }
}
