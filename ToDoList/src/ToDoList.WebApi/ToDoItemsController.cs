namespace ToDoList.WebApi;

using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;

[Route("api/[controller]")] //localhost:5000/api/ToDoItems
[ApiController]
public class ToDoItemsController : ControllerBase
{
    private static List<ToDoItem> items = [];

    [HttpPost]
    public IActionResult Create(ToDoItemCreateRequestDto request) // použijeme DTO - Data Transfer Object
    {
        return Ok(); // kód 200
    }

    [HttpGet]
    public IActionResult Read()
    {
        return Ok();
    }

    [HttpGet("{toDoItemId:int}")]
    public IActionResult ReadById(int toDoItemId, [FromBody] ToDoItemUpdateRequestDto request)
    {
        try
        {
            throw new Exception("Neco se opravdu nepovedlo");
        }
        catch(Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError); //500
        }

        return Ok();
    }

    [HttpPut]
    public IActionResult UpdateById()
    {
        return Ok();
    }

    [HttpDelete]
    public IActionResult DeleteById()
    {
        return Ok();
    }
}
