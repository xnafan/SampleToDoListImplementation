namespace ToDoListClassLibrary;
public class ToDoItem
{
    public int Id { get; set; }
    public string Name { get; set; } = "unnamed";
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool Done { get; set; }

}
