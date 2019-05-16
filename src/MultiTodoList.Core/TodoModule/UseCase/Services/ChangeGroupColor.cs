using System;
using System.Linq;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;

namespace MultiTodoList.Core.TodoModule.UseCase.Services
{
    public interface IChangeGroupColor
    {
        void Execute(Guid userId, Name groupName, Color groupColor);
    }

    public class ChangeGroupColor : IChangeGroupColor
    {
        private readonly IUserRepository _repository;

        public ChangeGroupColor(IUserRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid userId, Name groupName, Color groupColor)
        {
            var user = _repository.Get(userId);
            var group = user.Groups.FirstOrDefault(g => g.Name == groupName);
            group.ChangeColor(groupColor);
            _repository.Update(user);
        }
    }
}