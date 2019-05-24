using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;
using MultiTodoList.Core.TodoModule.UseCase.Services;

namespace MultiTodoList.Presentation.Controllers
{
    [Route("api/v1/users/{userId}/groups/{groupName}/todos/")]
    [ApiController]
    public class TodoController:ControllerBase
    {
        private readonly ICreateTodo _createTodo;
        private readonly IMakeCompletedTodo _makeCompletedTodo;
        private readonly IRemoveTodo _removeTodo;

        public TodoController(ICreateTodo createTodo, IMakeCompletedTodo makeCompletedTodo, IRemoveTodo removeTodo)
        {
            _createTodo = createTodo;
            _makeCompletedTodo = makeCompletedTodo;
            _removeTodo = removeTodo;
        }

        [HttpPost("{todoName}")]
        public async Task Post(Guid userId, string groupName,string todoName)
        {
            await _createTodo.Execute(new Name(todoName), userId, new Name(groupName));
        }
        
        [HttpPut("{todoName}")]
        public async Task Put(Guid userId, string groupName,string todoName)
        {
            await _makeCompletedTodo.Execute(new Name(todoName), userId, new Name(groupName));
        }
        
        [HttpDelete("{todoName}")]
        public async Task Delete(Guid userId, string groupName,string todoName)
        {
            await _removeTodo.Execute(new Name(todoName), userId, new Name(groupName));
        }
    }
}