using System.Collections.Generic;
using System.Threading.Tasks;
using DotnetApiDemo.Dtos.Todo;
using DotnetApiDemo.Models;

namespace DotnetApiDemo.Services.TodoService
{
    public interface ITodoService
    {
        Task<ServiceResponse<List<GetTodoDto>>> GetAllTodos();

        Task<ServiceResponse<GetTodoDto>> GetTodoById(int id);

         Task<ServiceResponse<List<GetTodoDto>>> AddTodo(AddTodoDto newCharacter);

         Task<ServiceResponse<GetTodoDto>> UpdateTodo(UpdateTodoDto updatedCharacter);

         Task<ServiceResponse<List<GetTodoDto>>> DeleteTodo(int id);
    }
}