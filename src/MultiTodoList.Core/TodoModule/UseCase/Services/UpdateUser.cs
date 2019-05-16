using System;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;

namespace MultiTodoList.Core.TodoModule.UseCase.Services
{
    public interface IUpdateUser
    {
        void Execute(Guid id, Name name, Age age, Photo photo);
    }

    public class UpdateUser : IUpdateUser
    {
        private readonly IUserRepository _repository;

        public UpdateUser(IUserRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id, Name name, Age age, Photo photo)
        {
            var user = _repository.Get(id);
            user.UpdateInfo(photo,name,age);
            _repository.Update(user);
        }
    }
}