namespace ToDoList.Domain.Models;

public class ToDoItem
{
    public string Name { get; set; }

    public int ToDoItemId { get; set; }

    public string Description { get; set; }

    public bool IsCompleted { get; set; }
}
