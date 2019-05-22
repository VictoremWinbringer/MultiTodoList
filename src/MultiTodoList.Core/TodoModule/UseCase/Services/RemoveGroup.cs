using System;
using System.Threading.Tasks;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;

namespace MultiTodoList.Core.TodoModule.UseCase.Services
{
    public interface IRemoveGroup
    {
        Task Execute(Guid userId, Name groupName);
    }

    public class RemoveGroup : IRemoveGroup
    {
        private readonly IUserRepository _repository;

        public RemoveGroup(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task Execute(Guid userId, Name groupName)
        {
            var user = await _repository.Get(userId);
            user.RemoveGroup(groupName);
            await _repository.Update(user);
        }
    }
}