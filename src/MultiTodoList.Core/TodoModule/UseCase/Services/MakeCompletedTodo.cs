using System;
using System.Linq;
using System.Threading.Tasks;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;

namespace MultiTodoList.Core.TodoModule.UseCase.Services
{
    public interface IMakeCompletedTodo
    {
        Task Execute(Name todoName, Guid userId, Name groupName);
    }

    public class MakeCompletedTodo : IMakeCompletedTodo
    {
        private readonly IUserRepository _repository;

        public MakeCompletedTodo(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task Execute(Name todoName, Guid userId, Name groupName)
        {
            var user = await _repository.Get(userId);
            var group = user.Groups.FirstOrDefault(g => g.Name == groupName);
            var todo = group.Todos.FirstOrDefault(t => t.Name == todoName);
            todo.MakeCompleted();
            await _repository.Update(user);
        }
    }
}