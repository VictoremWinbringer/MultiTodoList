using System;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;

namespace MultiTodoList.Core.TodoModule.Domain.Exceptions
{
    public class UserHaveTodoWithThisNameException : Exception
    {
        public Name Name { get; }

        public UserHaveTodoWithThisNameException(Name name)
        {
            Name = name;
        }
    }
}