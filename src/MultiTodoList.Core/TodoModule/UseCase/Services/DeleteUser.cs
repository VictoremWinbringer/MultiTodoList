using System;
using System.Threading.Tasks;

namespace MultiTodoList.Core.TodoModule.UseCase.Services
{
    public interface IDeleteUser
    {
        Task Execute(Guid id);
    }

    public class DeleteUser : IDeleteUser
    {
        private readonly IUserRepository _repository;

        public DeleteUser(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task Execute(Guid id)
        {
          await  _repository.Remove(id);
        }
    }
}