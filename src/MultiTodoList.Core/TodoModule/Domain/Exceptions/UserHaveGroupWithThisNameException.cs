using System;

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