using System;
using System.Net.Sockets;
using MultiTodoList.Core.TodoModule.Domain;

namespace MultiTodoList.Core.TodoModule.UseCase
{
    public interface IUserRepository
    {
        void Add(User user);
        void Remove(User user);
        void Save(User user);
        User Get(Guid id);
    }
}