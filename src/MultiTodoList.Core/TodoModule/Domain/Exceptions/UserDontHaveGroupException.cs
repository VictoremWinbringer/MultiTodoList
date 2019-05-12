using System;

namespace MultiTodoList.Core.TodoModule.Domain.Exceptions
{
    public class UserDontHaveGroupException : Exception
    {
        public Guid GroupId { get; }

        public UserDontHaveGroupException(Guid groupId)
        {
            GroupId = groupId;
        }
    }
}