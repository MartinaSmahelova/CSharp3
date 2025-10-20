namespace ToDoList.Domain.DTOs;

using ToDoList.Domain.Models;

public class ToDoItemGetResponseDto
{
    public ToDoItemGetResponseDto(int toDoItemId, string name, string description, bool isCompleted)
    {
        ToDoItemId = toDoItemId;
        Name = name;
        Description = description;
        IsCompleted = isCompleted;
    }

    public int ToDoItemId { get; }
    public string Name { get; }
    public string Description { get; }
    public bool IsCompleted { get; }

    public static ToDoItemGetResponseDto FromDomain(ToDoItem item) => new(item.ToDoItemId, item.Name, item.Description, item.IsCompleted);
}
