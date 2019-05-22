using System.Threading.Tasks;
using MultiTodoList.Core.TodoModule.Domain;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;

namespace MultiTodoList.Core.TodoModule.UseCase.Services
{
    public interface ICreateUser
    {
        Task Execute( Name name, Age age, Photo photo);
    }

    public class CreateUser : ICreateUser
    {
        private readonly IUserRepository _repository;

        public CreateUser(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task Execute( Name name, Age age, Photo photo)
        {
            var user = new User(photo,age,name);
           await _repository.Create(user);
        }
    }
}