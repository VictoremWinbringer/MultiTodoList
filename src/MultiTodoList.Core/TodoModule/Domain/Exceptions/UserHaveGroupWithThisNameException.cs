using System;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;

namespace MultiTodoList.Core.TodoModule.Domain.Exceptions
{
    public sealed class UserHaveGroupWithThisNameException : Exception
    {
        public Name Name { get; }

        public UserHaveGroupWithThisNameException(Name name)
        {
            Name = name;
        }
    }
}