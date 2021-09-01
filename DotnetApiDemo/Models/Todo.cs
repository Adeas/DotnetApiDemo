using System.Collections.Generic;

namespace DotnetApiDemo.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public bool Done { get; set; } = false;
        public User User { get; set; }
    }
}