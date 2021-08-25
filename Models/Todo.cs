using System.Collections.Generic;

namespace dotnet_api.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public bool Done { get; set; } = false;
        public User User { get; set; }
    }
}