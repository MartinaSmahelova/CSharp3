namespace ToDoList.Test;

using Moq;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;
using ToDoList.WebApi;


public class UpdateByIdTests
{
    [Fact]
    public void UpdateByIdReturnsNoContentWhenItemExists()
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

        var request = new ToDoItemUpdateRequestDto("Name", "Description", true);

        // Act
        var result = controller.UpdateById(1, request);
        int? statusCode = result.GetStatusCode();

        // Assert
        Assert.Equal(statusCode, 204); //204 is No Content status code
    }

    [Fact]
    public void UpdateByIdReturnsNotFoundWhenItemDoesNotExist()
    {
        // Arrange
        var controller = new ToDoItemsController();
        var request = new ToDoItemUpdateRequestDto("Name", "Description", true);

        // Act
        var result = controller.UpdateById(99, request);
        int? statusCode = result.GetStatusCode();

        // Assert
        Assert.Equal(statusCode, 404); //404 is Not Found status code
    }

}
