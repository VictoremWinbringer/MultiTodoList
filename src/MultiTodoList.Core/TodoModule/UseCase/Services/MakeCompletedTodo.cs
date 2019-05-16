using System;
using System.Linq;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;

namespace MultiTodoList.Core.TodoModule.UseCase.Services
{
    public interface IMakeCompletedTodo
    {
        void Execute(Name todoName, Guid userId, Name groupName);
    }

    public class MakeCompletedTodo : IMakeCompletedTodo
    {
        private readonly IUserRepository _repository;

        public MakeCompletedTodo(IUserRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Name todoName, Guid userId, Name groupName)
        {
            var user = _repository.Get(userId);
            var group = user.Groups.FirstOrDefault(g => g.Name == groupName);
            var todo = group.Todos.FirstOrDefault(t => t.Name == todoName);
            todo.MakeCompleted();
            _repository.Update(user);
        }
    }
}