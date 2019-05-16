using System;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;

namespace MultiTodoList.Core.TodoModule.Domain.Exceptions
{
    public class UserDontHaveGroupException : Exception
    {
        public Name GroupId { get; }

        public UserDontHaveGroupException(Name groupId)
        {
            GroupId = groupId;
        }
    }
}