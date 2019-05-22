using System;
using System.Threading.Tasks;
using MultiTodoList.Core.TodoModule.Domain;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;

namespace MultiTodoList.Core.TodoModule.UseCase.Services
{
    public interface ICreateGroup
    {
        Task Execute(Guid userId, Name groupName, Color groupColor);
    }
    
    public class CreateGroup :ICreateGroup
    {
        private readonly IUserRepository _repository;

        public CreateGroup(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task Execute(Guid userId, Name groupName, Color groupColor)
        {
            var user = await _repository.Get(userId);
            var group = new TodoGroup(groupName, groupColor);
            user.Add(group);
           await _repository.Update(user);
        }
    }
}