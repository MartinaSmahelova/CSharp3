namespace ToDoList.Test;

using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.Models;
using ToDoList.WebApi;

public class DeleteByIdTest
{
    [Fact]
    public void DeleteByIdReturnsNoCOntentWhenRemovesItemFromList()
    {
        // Arrange
        var controller = new ToDoItemsController();
        var itemToUpdate = new ToDoItem
        {
            ToDoItemId = 1,
            Name = "Name1",
            Description = "Description1",
            IsCompleted = false
        };
        controller.AddItemToStorage(itemToUpdate);

        // Act
        var result = controller.DeleteById(1);
        var noItem = result.GetValue();
        int? statusCode = result.GetStatusCode();

        // Assert
        Assert.Null(noItem);
        Assert.Equal(statusCode, 204); //204 is No Content status code
    }

    [Fact]
    public void DeleteByIdReturnsNotFoundWhenItemDoesNotExist()
    {
        // Arrange
        var controller = new ToDoItemsController();

        // Act
        var result = controller.DeleteById(123);
        int? statusCode = result.GetStatusCode();

        // Assert
        Assert.Equal(statusCode, 404); //404 is Not Found status code
    }

}
