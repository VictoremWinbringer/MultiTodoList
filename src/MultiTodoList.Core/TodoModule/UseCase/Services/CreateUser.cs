using MultiTodoList.Core.TodoModule.Domain;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;

namespace MultiTodoList.Core.TodoModule.UseCase.Services
{
    public interface ICreateUser
    {
        void Execute( Name name, Age age, Photo photo);
    }

    public class CreateUser : ICreateUser
    {
        private readonly IUserRepository _repository;

        public CreateUser(IUserRepository repository)
        {
            _repository = repository;
        }

        public void Execute( Name name, Age age, Photo photo)
        {
            var user = new User(photo,age,name);
            _repository.Create(user);
        }
    }
}