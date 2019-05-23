using System;
using System.Threading.Tasks;
using MultiTodoList.Core.TodoModule.Domain;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;

namespace MultiTodoList.Core.TodoModule.UseCase.Services
{
    public interface ICreateUser
    {
        Task<Guid> Execute(User user);
    }

    public class CreateUser : ICreateUser
    {
        private readonly IUserRepository _repository;

        public CreateUser(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Execute(User user)
        {
            var newUser = new User(user.Photo, user.Age, user.Name, new byte[0]);
            await _repository.Create(newUser);
            return newUser.Id;
        }
    }
}