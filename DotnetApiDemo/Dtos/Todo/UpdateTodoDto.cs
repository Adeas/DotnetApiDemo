namespace DotnetApiDemo.Dtos.Todo
{
    public class UpdateTodoDto
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public bool Done { get; set; }
    }
}