using System.Collections.Generic;

namespace ToDoList.Models
{
  public class Item
  {
    public static List<Item> _instances = new List<Item> {};
    private string _type;
    private string _date;
    private string _description;
    private string _importance;
    private int _id;


    public Item(string type, string date, string description, string importance)
      {
        _type = type;
        _date = date;
        _description = description;
        _importance = importance;
        _id = _instances.Count;
      }

    public string GetType()
    {
      return _type;
    }

    public void SetType(string newType)
    {
      _type = newType;
    }

    public string GetDate()
    {
      return _date;
    }

    public void SetDate(string newDate)
    {
      _date = newDate;
    }

    public string GetDescription()
    {
      return _description;
    }

    public void SetDescription(string newDescription)
    {
      _description = newDescription;
    }

    public string GetImportance()
    {
      return _importance;
    }

    public void SetImportance(string newImportance)
    {
      _importance = newImportance;
    }

    public int GetId()
    {
      return _id + 1;
    }

    public static List<Item> GetAll()
    {
      return _instances;
    }

    public static List<Item> Find()
    {
      return _instances;
    }

    public void Save()
    {
      _instances.Add(this);
    }

  }
}
