using ToDoListClassLibrary;

namespace ToDoListDAL.InMemory;

public class InMemoryToDoListDao : IToDoListDao
{
    private int _nextId = 1;
    private List<ToDoItem> _toDoList = new List<ToDoItem>();

    public IEnumerable<ToDoItem> GetAll()
    {
        return _toDoList;
    }

    public ToDoItem GetById(int id)
    {
        return _toDoList.FirstOrDefault(x => x.Id == id);
    }

    public IEnumerable<ToDoItem> GetByPartOfName(string partOfName)
    {
        return _toDoList.Where(x => x.Name.Contains(partOfName));
    }

    public bool Delete(int id)
    {
        var item = GetById(id);
        if (item != null)
        {
            _toDoList.Remove(item);
            return true;
        }

        return false;
    }

    public void Add(ToDoItem item)
    {
        item.Id = _nextId++;
        _toDoList.Add(item);
    }

    public bool Update(ToDoItem item)
    {
        var foundItem = GetById(item.Id);
        if(foundItem != null)
        {
            foundItem.Name = item.Name;
            foundItem.Description = item.Description;
            foundItem.DueDate = item.DueDate;
            foundItem.Done = item.Done;
        }
        return foundItem != null;
    }
}
