using System.Collections.Generic;

namespace ToDoList.Models
{
  public class ToDo
  {
    private string _item;
    private string _date;
    private string _description;
    private string _importance;
    private int _id;

    public ToDo(string item, string date, string description, string importance)
      {
        _item = item;
        _date = date;
        _description = description;
        _importance = importance;
        _id = _instances.Count;
      }
    public static List<ToDo> _instances = new List<ToDo> {};

    public string GetItem()
    {
      return _item;
    }

    public void SetItem(string newItem)
    {
      _item = newItem;
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
      return _id;
    }
    public static List<ToDo> GetAll()
    {
      return _instances;
    }
    public void Save()
    {
      _instances.Add(this);
    }
  }
}
