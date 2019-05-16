using System;
using System.Collections.Generic;
using System.Net.Sockets;
using MultiTodoList.Core.TodoModule.Domain;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;

namespace MultiTodoList.Core.TodoModule.UseCase
{
    public interface IUserRepository
    {
        
        void Create(User user);
        
        User Get(Guid id);

        List<User> Get();

        void Update(User user);
        
        void Remove(Guid id);

        bool Contains(Name todoName);
    }
}