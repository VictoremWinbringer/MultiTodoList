using System;

namespace MultiTodoList.Core.TodoModule.Domain.Exceptions
{
    public sealed class TodoExistInGroupException : Exception
    {
        public Guid Id { get; }

        public TodoExistInGroupException(Guid id)
        {
            Id = id;
        }
    }
}