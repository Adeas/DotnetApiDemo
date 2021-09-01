using Xunit;
using DotnetApiDemo.Services.TodoService;
using System.Threading.Tasks;
using Moq;

namespace DotnetApiDemo.UnitTests
{
    public class TodoServiceTest
    {
        [Fact]
        public async Task GetUserId_ReturnsInt()
        {
            // Arrange
            var todoServiceStub = new Mock<ITodoService>();
            var controller = new TodoController(todoServiceStub.Object);
            // Act
            var result = await controller.GetSingle(1);
            //  Assert
            Assert.IsType<ActionResult<ServiceResponse<GetTodoDto>>>(result);
        }
    }
}