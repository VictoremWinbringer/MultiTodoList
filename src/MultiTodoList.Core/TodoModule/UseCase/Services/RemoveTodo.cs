using System;
using System.Linq;
using System.Threading.Tasks;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;

namespace MultiTodoList.Core.TodoModule.UseCase.Services
{
    public interface IRemoveTodo
    {
        Task Execute(Name todoName, Guid userId, Name groupName);
    }

    public class RemoveTodo : IRemoveTodo
    {
        private readonly IUserRepository _repository;

        public RemoveTodo(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task Execute(Name todoName, Guid userId, Name groupName)
        {
            var user = await _repository.Get(userId);
            var group = user.Groups.FirstOrDefault(g => g.Name == groupName);
            group.RemoveTodo(todoName);
            await _repository.Update(user);
        }
    }
}