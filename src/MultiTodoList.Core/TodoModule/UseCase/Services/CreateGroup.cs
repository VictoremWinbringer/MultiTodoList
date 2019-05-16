using System;
using MultiTodoList.Core.TodoModule.Domain;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;

namespace MultiTodoList.Core.TodoModule.UseCase.Services
{
    public interface ICreateGroup
    {
        void Execute(Guid userId, Name groupName, Color groupColor);
    }
    
    public class CreateGroup :ICreateGroup
    {
        private readonly IUserRepository _repository;

        public CreateGroup(IUserRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid userId, Name groupName, Color groupColor)
        {
            var user = _repository.Get(userId);
            var group = new TodoGroup(groupName, groupColor);
            user.Add(group);
            _repository.Update(user);
        }
    }
}