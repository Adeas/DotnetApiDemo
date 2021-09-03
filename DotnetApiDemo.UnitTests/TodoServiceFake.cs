using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DotnetApiDemo.Dtos.Todo;
using DotnetApiDemo.Models;
using DotnetApiDemo.Services.TodoService;

namespace DotnetApiDemo.UnitTests
{
    public class TodoServiceFake : ITodoService
    {
        private readonly List<AddTodoDto> _todoDto;
        private readonly IMapper _mapper;

        public TodoServiceFake(IMapper mapper)
        {
            _mapper = mapper;
            _todoDto = new List<AddTodoDto>()
                {
                    new AddTodoDto() {
                        Message = "Message 1"
                    },
                    new AddTodoDto() {
                        Message = "Message 2"
                    },
                    new AddTodoDto() {
                        Message = "Message 3"
                    }
                };
        }

        public Task<ServiceResponse<List<GetTodoDto>>> AddTodo(AddTodoDto newTodo)
        {
            var serviceResponse = new ServiceResponse<List<GetTodoDto>>();
            _todoDto.Add(newTodo);
            serviceResponse.Data = _mapper.Map<AddTodoDto>(_todoDto);
            return serviceResponse;
        }

        public Task<ServiceResponse<List<GetTodoDto>>> DeleteTodo(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResponse<List<GetTodoDto>>> GetAllTodos()
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResponse<GetTodoDto>> GetTodoById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResponse<GetTodoDto>> UpdateTodo(UpdateTodoDto updatedCharacter)
        {
            throw new System.NotImplementedException();
        }
    }
}