using System;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;

namespace MultiTodoList.Core.TodoModule.UseCase.Services
{
    public interface IRemoveGroup
    {
        void Execute(Guid userId, Name groupName);
    }

    public class RemoveGroup : IRemoveGroup
    {
        private readonly IUserRepository _repository;

        public RemoveGroup(IUserRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid userId, Name groupName)
        {
            var user = _repository.Get(userId);
            user.RemoveGroup(groupName);
            _repository.Update(user);
        }
    }
}