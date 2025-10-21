namespace ToDoList.Test;

using System.Linq;
using ToDoList.Domain.Models;
using ToDoList.WebApi;

public class GetTests
{
    [Fact]
    public void ReadReturnsAllStoredItem()
    {
        //Arrange
        var storedToDoItem1 = new ToDoItem
        {
            ToDoItemId = 1,
            Name = "Name1",
            Description = "Description1",
            IsCompleted = false
        };

        var storedToDoItem2 = new ToDoItem
        {
            ToDoItemId = 2,
            Name = "name2",
            Description = "Description2",
            IsCompleted = true
        };

        var controler = new ToDoItemsController();
        controler.AddItemToStorage(storedToDoItem1);
        controler.AddItemToStorage(storedToDoItem2);

        //Act
        var result = controler.Read();
        var readedToDoItem = result.GetValue()!.ToList();

        //Asert
        Assert.NotNull(readedToDoItem);
        Assert.Equal(2, readedToDoItem!.Count);

        Assert.Equal(storedToDoItem1.ToDoItemId, readedToDoItem[0].ToDoItemId);
        Assert.Equal(storedToDoItem1.Name, readedToDoItem[0].Name);
        Assert.Equal(storedToDoItem1.Description, readedToDoItem[0].Description);
        Assert.Equal(storedToDoItem1.IsCompleted, readedToDoItem[0].IsCompleted);

        Assert.Equal(storedToDoItem2.ToDoItemId, readedToDoItem[1].ToDoItemId);
        Assert.Equal(storedToDoItem2.Name, readedToDoItem[1].Name);
        Assert.Equal(storedToDoItem2.Description, readedToDoItem[1].Description);
        Assert.Equal(storedToDoItem2.IsCompleted, readedToDoItem[1].IsCompleted);

    }

    [Fact]
    public void ReadReturnsOkWhenAtLeastOneItemIsStored()
    {
        //Arrange
        var storedToDoItem = new ToDoItem
        {
            ToDoItemId = 1,
            Name = "Jmeno",
            Description = "Description",
            IsCompleted = false
        };

        var controler = new ToDoItemsController();
        controler.AddItemToStorage(storedToDoItem);

        //Act
        var result = controler.Read();
        var readedToDoItem = result.GetValue()!.ToList();
        int? statusCode = result.GetStatusCode();

        //Asert
        Assert.NotNull(readedToDoItem);
        Assert.Single(readedToDoItem!);
        Assert.Equal(statusCode, 200); //200 is OK status code
    }

    [Fact]
    public void ReadReturnsNotFoundWhenNoItemsExist()
    {
        // Arrange
        var controller = new ToDoItemsController();

        // Act
        var result = controller.Read();
        var readedToDoItem = result.GetValue();
        int? statusCode = result.GetStatusCode();

        // Assert
        Assert.Null(readedToDoItem);
        Assert.Equal(statusCode, 404); //404 is Not Found status code
    }
}
