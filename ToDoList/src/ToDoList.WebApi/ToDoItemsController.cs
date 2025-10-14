namespace ToDoList.WebApi;

using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;

[Route("api/[controller]")] //localhost:5000/api/ToDoItems
[ApiController]
public class ToDoItemsController : ControllerBase
{
    private static readonly List<ToDoItem> items = [];

    [HttpPost]
    public IActionResult Create(ToDoItemCreateRequestDto request) // použijeme DTO - Data Transfer Object
    {
        try
        {
            var item = request.ToDomain();

            item.ToDoItemId = items.Count == 0 ? 1 : items.Max(i => i.ToDoItemId) + 1;
            items.Add(item);


            return CreatedAtAction(nameof(ReadById), new { toDoItemId = item.ToDoItemId },
                    ToDoItemGetResponseDto.FromDomain(item));
        }

        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError); //500
        }
    }

    [HttpGet] // api/ToDoITems/ GET
    public IActionResult Read()
    {
        try
        {

            if (items != null && items.Count != 0)
            {
                var response = items.Select(ToDoItemGetResponseDto.FromDomain).ToList();
                return Ok(response);
            }

            return NotFound();
        }

        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("{toDoItemId:int}")] // api/ToDoITems/<id> GET
    public IActionResult ReadById(int toDoItemId)
    {
        try
        {
            ToDoItem? item = items.Find(i => i.ToDoItemId == toDoItemId);

            if (item != null)
            {
                return Ok(ToDoItemGetResponseDto.FromDomain(item));
            }

            return NotFound();
        }

        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError); //500
        }

    }

    [HttpPut("{toDoItemId:int}")]
    public IActionResult UpdateById(int toDoItemId, [FromBody] ToDoItemUpdateRequestDto request)
    {
        try
        {
            var itemToUpdate = items.Find(i => i.ToDoItemId == toDoItemId);

            if (itemToUpdate != null)
            {
                ToDoItem updatedItem = request.ToDomain();
                updatedItem.ToDoItemId = toDoItemId;

                int index = items.FindIndex(i => i.ToDoItemId == toDoItemId);
                items[index] = updatedItem;
            }

            return NoContent();
        }

        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError); //500
        }
    }

    [HttpDelete("{toDoItemId:int}")]
    public IActionResult DeleteById(int toDoItemId)
    {
         try
        {
            ToDoItem? item = items.Find(i => i.ToDoItemId == toDoItemId);

            if (item != null)
            {
                items.Remove(item);

                return NoContent();
            }

            return NotFound();
        }

        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError); //500
        }
    }
}
