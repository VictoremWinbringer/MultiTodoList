using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading.Tasks;
using MultiTodoList.Core.TodoModule.Domain;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;

namespace MultiTodoList.Core.TodoModule.UseCase
{
    public interface IUserRepository
    {
        Task Create(User user);

        Task<User> Get(Guid id);

        Task<List<User>> Get();

        Task Update(User user);

        Task Remove(Guid id);

        Task<bool> Contains(Name todoName);
    }
}