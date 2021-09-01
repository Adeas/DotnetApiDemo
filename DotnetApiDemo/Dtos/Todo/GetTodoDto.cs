using DotnetApiDemo.Models;

namespace DotnetApiDemo.Dtos.Todo
{
    public class GetTodoDto
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public bool Done { get; set; }
    }
}