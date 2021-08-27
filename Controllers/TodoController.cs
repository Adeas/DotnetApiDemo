using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DotnetApiDemo.Dtos.Todo;
using DotnetApiDemo.Models;
using DotnetApiDemo.Services.TodoService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotnetApiDemo.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetTodoDto>>>> Get()
        {
            return Ok(await _todoService.GetAllTodos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetTodoDto>>> GetSingle(int id)
        {
            return Ok(await _todoService.GetTodoById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetTodoDto>>>> AddTodo(AddTodoDto newTodo)
        {
            return Ok(await _todoService.AddTodo(newTodo));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetTodoDto>>> UpdateCharacter(UpdateTodoDto updateTodo)
        {
            var response = await _todoService.UpdateTodo(updateTodo);
            if(response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetTodoDto>>>> Delete(int id)
        {
            var response = await _todoService.DeleteTodo(id);
            if(response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}