using ToDoListClassLibrary;

namespace ToDoListDAL.InMemory;

public class InMemoryToDoListDao : IToDoListDao
{
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
        _toDoList.Add(item);
    }

    public void Update(ToDoItem item)
    {
        var index = _toDoList.FindIndex(x => x.Id == item.Id);
        if (index != -1)
        {
            _toDoList[index] = item;
        }
    }
