using System;

namespace MultiTodoList.Core.TodoModule.UseCase.Services
{
    public interface IDeleteUser
    {
        void Execute(Guid id);
    }

    public class DeleteUser : IDeleteUser
    {
        private readonly IUserRepository _repository;

        public DeleteUser(IUserRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id)
        {
            _repository.Remove(id);
        }
    }
}