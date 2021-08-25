using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_api.Dtos.Todo;
using dotnet_api.Models;

namespace dotnet_api.Services.TodoService
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