namespace ToDoList.Test;

using ToDoList.Domain.Models;
using ToDoList.WebApi;

public class ReadeByIdTests
{
    [Fact]
    public void ReadByIdReturnsOkWhenItemExists()
    {
        // Arrange
        var controller = new ToDoItemsController();
        var itemToRead = new ToDoItem
        {
            ToDoItemId = 1,
            Name = "Name1",
            Description = "Description1",
            IsCompleted = false
        };
        controller.AddItemToStorage(itemToRead);

        // Act
        var result = controller.ReadById(1);
        var readedByIdToDoItem = result.GetValue();
        int? statusCode = result.GetStatusCode();

        // Assert
        Assert.NotNull(readedByIdToDoItem);
        Assert.Equal(statusCode, 200); //200 is OK status code
    }

    [Fact]
    public void ReadByIdReturnsNotFoundWhenItemDoesNotExist()
    {
        // Arrange
        var controller = new ToDoItemsController();

        // Act
        var result = controller.ReadById(99);
        var readedByIdToDoItem = result.GetValue();
        int? statusCode = result.GetStatusCode();

        // Assert
        Assert.Null(readedByIdToDoItem);
        Assert.Equal(statusCode, 404); //404 is Not Found status code
    }

    [Fact]
    public void ReadByIdReturnsNotFoundWhenItemHasWrongId()
    {
        // Arrange
        var controller = new ToDoItemsController();
        var itemToRead = new ToDoItem
        {
            ToDoItemId = 1,
            Name = "Name1",
            Description = "Description1",
            IsCompleted = false
        };
        controller.AddItemToStorage(itemToRead);

        // Act
        var result = controller.ReadById(2);
        var readedByIdToDoItem = result.GetValue();
        int? statusCode = result.GetStatusCode();

        // Assert
        Assert.Null(readedByIdToDoItem);
        Assert.Equal(statusCode, 404); //404 is Not Found status code
    }
}
