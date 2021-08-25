using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_api.Data;
using dotnet_api.Dtos.Todo;
using dotnet_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace dotnet_api.Services.TodoService
{
    public class TodoService : ITodoService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TodoService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _mapper = mapper;

        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        public async Task<ServiceResponse<List<GetTodoDto>>> GetAllTodos()
        {
            var serviceResponse = new ServiceResponse<List<GetTodoDto>>();
            var dbTodos = await _context.Todos
                .Where(c => c.User.Id == GetUserId()).ToListAsync();
            serviceResponse.Data = dbTodos.Select(c => _mapper.Map<GetTodoDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetTodoDto>>> AddTodo(AddTodoDto newTodo)
        {
            var serviceResponse = new ServiceResponse<List<GetTodoDto>>();
            Todo todo = _mapper.Map<Todo>(newTodo);
            todo.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());

            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Todos
                .Where(u => u.User.Id == GetUserId())
                .Select(c => _mapper.Map<GetTodoDto>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTodoDto>> GetTodoById(int id)
        {
            var serviceResponse = new ServiceResponse<GetTodoDto>();
            var dbTodo = await _context.Todos
                .FirstOrDefaultAsync(t => t.Id == id && t.User.Id == GetUserId());
            serviceResponse.Data = _mapper.Map<GetTodoDto>(dbTodo);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetTodoDto>>> DeleteTodo(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetTodoDto>>();
            try
            {
                Todo todo = await _context.Todos.FirstOrDefaultAsync(t => t.Id == id && t.User.Id == GetUserId());
                if (todo != null)
                {
                    _context.Todos.Remove(todo);
                    await _context.SaveChangesAsync();

                    serviceResponse.Data = _context.Todos
                        .Where(u => u.User.Id == GetUserId())
                        .Select(c => _mapper.Map<GetTodoDto>(c)).ToList();
                }
                else 
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Todo item not found.";
                }
                
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTodoDto>> UpdateTodo(UpdateTodoDto updatedTodo)
        {
            var serviceResponse = new ServiceResponse<GetTodoDto>();
            try
            {
                Todo todo = await _context.Todos
                    .Include(u => u.User)
                    .FirstOrDefaultAsync(t => t.Id == updatedTodo.Id);
                if (todo.User.Id == GetUserId())
                {
                    todo.Message = updatedTodo.Message;
                    todo.Done = updatedTodo.Done;

                    await _context.SaveChangesAsync();

                    serviceResponse.Data = _mapper.Map<GetTodoDto>(todo);
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Todo item to update not found.";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}