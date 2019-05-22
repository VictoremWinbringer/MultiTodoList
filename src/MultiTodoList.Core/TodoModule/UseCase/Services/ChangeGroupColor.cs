using System;
using System.Linq;
using System.Threading.Tasks;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;

namespace MultiTodoList.Core.TodoModule.UseCase.Services
{
    public interface IChangeGroupColor
    {
        Task Execute(Guid userId, Name groupName, Color groupColor);
    }

    public class ChangeGroupColor : IChangeGroupColor
    {
        private readonly IUserRepository _repository;

        public ChangeGroupColor(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task Execute(Guid userId, Name groupName, Color groupColor)
        {
            var user = await _repository.Get(userId);
            var group = user.Groups.FirstOrDefault(g => g.Name == groupName);
            group.ChangeColor(groupColor);
           await _repository.Update(user);
        }
    }
}