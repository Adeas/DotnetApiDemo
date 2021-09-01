using AutoMapper;
using DotnetApiDemo.Dtos.Todo;
using DotnetApiDemo.Models;

namespace DotnetApiDemo
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Todo, GetTodoDto>();
            CreateMap<AddTodoDto, Todo>();
        }
    }
}