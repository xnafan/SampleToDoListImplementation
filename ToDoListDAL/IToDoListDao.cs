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
        /// <summary>
        /// Searches for ToDoItems by part of name
        /// </summary>
        /// <param name="partOfName">a subset of the Name property</param>
        /// <returns>All ToDoItems which match the search string</returns>
        IEnumerable<ToDoItem> GetByPartOfName(string partOfName);
        bool Delete(int id);
        void Add(ToDoItem item);
        void Update(ToDoItem item);



    }
}