using System;
using Xunit;
using DotnetApiDemo.Controllers;
using DotnetApiDemo.Services.TodoService;
using DotnetApiDemo.Dtos.Todo;
using DotnetApiDemo.Models;
using Moq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DotnetApiDemo.UnitTests
{
    public class TodoControllerTests
    {
        [Fact]
        public async Task GetSingle_WithoutContext_ReturnsGetTodoDto()
        {
            // Testing controllers is usually not preferred, instead you should test services
            // This controller test is here only as example how to test controllers

            // Arrange
            var todoServiceStub = new Mock<ITodoService>();
            var controller = new TodoController(todoServiceStub.Object);
            // Act
            var result = await controller.GetSingle(1);
            //  Assert
            Assert.IsType<ActionResult<ServiceResponse<GetTodoDto>>>(result);
        }


        [Fact]
        public async Task GetItemsAsync_WithExistingItems_ReturnsAllItems()
        {
            // Arrange
            var expectedItems = new[]{CreateRandomTodo()};

            var todoServiceStub = new Mock<ITodoService>();
            var controller = new TodoController(todoServiceStub.Object);
            // Act

            // Assert
        }
        
        private Todo CreateRandomTodo() {
            Random rnd = new Random();
            return new()
            {
                Id = rnd.Next(100),
                Message = "Random text: " + Guid.NewGuid().ToString(),
                Done = false
            };
        }

        private List<GetTodoDto> GetTestTodoDtos()
        {
            var todos = new List<GetTodoDto>();
            todos.Add(new GetTodoDto()
            {
                Id = 1,
                Message = "Test message 1",
                Done = false
            });
            todos.Add(new GetTodoDto()
            {
                Id = 2,
                Message = "Test message 2",
                Done = false
            });
            return todos;
        }

        private GetTodoDto GetTestTodoDto()
        {
            var todo = new GetTodoDto()
            {
                Id = 1,
                Message = "Message contents",
                Done = false
            };
            return todo;     
        }
    }
}
