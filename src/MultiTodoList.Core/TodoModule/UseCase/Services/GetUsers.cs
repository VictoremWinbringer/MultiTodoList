using System.Collections.Generic;
using MultiTodoList.Core.TodoModule.Domain;

namespace MultiTodoList.Core.TodoModule.UseCase.Services
{
    public interface IGetUsers
    {
        List<User> Execute();
    }

    public class GetUsers : IGetUsers
    {
        private readonly IUserRepository _repository;

        public GetUsers(IUserRepository repository)
        {
            _repository = repository;
        }

        public List<User> Execute()
        {
            return _repository.Get();
        }
    }
}