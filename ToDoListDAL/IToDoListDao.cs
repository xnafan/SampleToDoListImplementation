using ToDoListClassLibrary;

namespace ToDoListDAL
{
    /// <summary>
    /// Represents an implementation agostic way of performing CRUD with ToDoItems.
    /// </summary>
    public interface IToDoListDao
    {
        IEnumerable<ToDoItem> GetAll();
        ToDoItem GetById(int id);
        IEnumerable<ToDoItem> GetByPartOfName(string partOfName);
        bool Delete(int id);
        int Add(ToDoItem item);
        bool Update(ToDoItem item);
    }
}