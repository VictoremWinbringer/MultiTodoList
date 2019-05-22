using System;
using System.Linq;
using System.Threading.Tasks;
using MultiTodoList.Core.TodoModule.Domain;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;

namespace MultiTodoList.Core.TodoModule.UseCase.Services
{
    public interface ICreateTodo
    {
        Task Execute(Name todoName, Guid userId, Name groupName);
    }

    public class CreateTodo : ICreateTodo
    {
        private readonly IUserRepository _repository;

        public CreateTodo(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task Execute(Name todoName, Guid userId, Name groupName)
        {
            if (await _repository.Contains(todoName))
                throw new TodoExistsException();

            var user = await _repository.Get(userId);
            var group = user.Groups.FirstOrDefault(g => g.Name == groupName);
            group.AddTodo(new Todo(todoName));
           await _repository.Update(user);
        }
    }
}