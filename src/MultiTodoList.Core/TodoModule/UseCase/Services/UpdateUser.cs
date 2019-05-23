using System;
using System.Threading.Tasks;
using MultiTodoList.Core.TodoModule.Domain;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;

namespace MultiTodoList.Core.TodoModule.UseCase.Services
{
    public interface IUpdateUser
    {
        Task Execute(User user);
    }

    public class UpdateUser : IUpdateUser
    {
        private readonly IUserRepository _repository;

        public UpdateUser(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task Execute(User user)
        {
            var oldUser = await _repository.Get(user.Id);
            oldUser.UpdateInfo(user);
            await _repository.Update(oldUser);
        }
    }
}