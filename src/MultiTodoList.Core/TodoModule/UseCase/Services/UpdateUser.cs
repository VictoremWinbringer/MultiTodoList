using System;
using System.Threading.Tasks;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;

namespace MultiTodoList.Core.TodoModule.UseCase.Services
{
    public interface IUpdateUser
    {
        Task Execute(Guid id, Name name, Age age, Photo photo);
    }

    public class UpdateUser : IUpdateUser
    {
        private readonly IUserRepository _repository;

        public UpdateUser(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task Execute(Guid id, Name name, Age age, Photo photo)
        {
            var user = await _repository.Get(id);
            user.UpdateInfo(photo, name, age);
            await _repository.Update(user);
        }
    }
}