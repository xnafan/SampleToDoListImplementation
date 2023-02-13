using ToDoListClassLibrary;

namespace ToDoListDAL.InMemory;

public class InMemoryToDoListDao : IToDoListDao
{
    private int _nextId = 1;
    private List<ToDoItem> _toDoList = new List<ToDoItem>();
    public InMemoryToDoListDao()
    {
        Add(new ToDoItem("Brush your teeth"));
        Add(new ToDoItem("Mow the lawn"));
        Add(new ToDoItem("Write Valentine's card"));
    }
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
        return _toDoList.Where(toDoItem
            => toDoItem.Name.Contains(partOfName));
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

    public int Add(ToDoItem item)
    {
        //HACK: sorry!
        //TODO: add synchronization
        var newIdUsed = _nextId;
        item.Id = _nextId++;
        _toDoList.Add(item);
        return newIdUsed;
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
