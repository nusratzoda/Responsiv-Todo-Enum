using Domain.Entites;
using Domain.Wraper;
using Infrastucture.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class Todocontroller
{

    private TodoServices _todoservices;
    public Todocontroller()
    {
        _todoservices = new TodoServices();
    }
    [HttpGet("GetTodo")]
    public async Task<Response<List<Todo>>> GetTodo()
    {
        return await _todoservices.GetTodo();
    }
    [HttpPost("AddTodo")]
    public async Task<Response<Todo>> AddTodo(Todo todo)
    {
        return await _todoservices.AddTodo(todo);
    }
    [HttpPut("UpdateTodo")]
    public async Task<Response<Todo>> UpdateTodo(Todo todo)
    {
        return await _todoservices.AddTodo(todo);
    }
    [HttpDelete("DeleteTodo")]
    public async Task<Response<int>> DeleteQuote(int id)
    {
        return await _todoservices.DeleteTodo(id);
    }
}
