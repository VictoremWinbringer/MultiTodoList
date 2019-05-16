using System;
using System.Linq;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;

namespace MultiTodoList.Core.TodoModule.UseCase.Services
{
    public interface IRemoveTodo
    {
        void Execute(Name todoName, Guid userId, Name groupName);
    }

    public class RemoveTodo : IRemoveTodo
    {
        private readonly IUserRepository _repository;

        public RemoveTodo(IUserRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Name todoName, Guid userId, Name groupName)
        {
            var user = _repository.Get(userId);
            var group = user.Groups.FirstOrDefault(g => g.Name == groupName);
            group.RemoveTodo(todoName);
            _repository.Update(user);
        }
    }
}