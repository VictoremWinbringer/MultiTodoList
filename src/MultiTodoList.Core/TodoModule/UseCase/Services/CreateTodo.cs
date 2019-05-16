using System;
using System.Linq;
using MultiTodoList.Core.TodoModule.Domain;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;

namespace MultiTodoList.Core.TodoModule.UseCase.Services
{
    public interface ICreateTodo
    {
        void Execute(Name todoName, Guid userId, Name groupName);
    }

    public class CreateTodo : ICreateTodo
    {
        private readonly IUserRepository _repository;

        public CreateTodo(IUserRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Name todoName, Guid userId, Name groupName)
        {
            if (_repository.Contains(todoName))
                throw new TodoExistsException();

            var user = _repository.Get(userId);
            var group = user.Groups.FirstOrDefault(g => g.Name == groupName);
            group.AddTodo(new Todo(todoName));
            _repository.Update(user);
        }
    }
}