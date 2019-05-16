using System;
using MultiTodoList.Core.TodoModule.Domain;

namespace MultiTodoList.Core.TodoModule.UseCase.Services
{
    public interface IGetUser
    {
        User Execute(Guid id);
    }

    public class GetUser : IGetUser
    {
        private readonly IUserRepository _repository;

        public GetUser(IUserRepository repository)
        {
            _repository = repository;
        }

        public User Execute(Guid id)
        {
            return _repository.Get(id);
        }
    }
}