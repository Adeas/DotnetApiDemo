using AutoMapper;
using dotnet_api.Dtos.Todo;
using dotnet_api.Models;

namespace dotnet_api
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