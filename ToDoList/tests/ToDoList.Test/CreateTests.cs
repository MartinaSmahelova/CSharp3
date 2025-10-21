namespace ToDoList.Test;

using ToDoList.Domain.DTOs;
using ToDoList.WebApi;

public class CreateTests
{
    [Fact]
    public void CreateReturnsCreatedItem()
    {
        // Arrange
        var controller = new ToDoItemsController();
        var request = new ToDoItemCreateRequestDto("Name", "Description", false);

        // Act
        var result = controller.Create(request);
        var createdItem = result.GetValue();

        // Assert
        Assert.NotNull(createdItem);
        Assert.Equal(1, createdItem!.ToDoItemId);
        Assert.Equal("Name", createdItem.Name);
        Assert.Equal("Description", createdItem.Description);
        Assert.False(createdItem.IsCompleted);
    }

}

