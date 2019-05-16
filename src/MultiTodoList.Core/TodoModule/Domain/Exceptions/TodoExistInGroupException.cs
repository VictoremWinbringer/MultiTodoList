using System;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;

namespace MultiTodoList.Core.TodoModule.Domain.Exceptions
{
    public sealed class TodoExistInGroupException : Exception
    {
        public Name Name { get; }

        public TodoExistInGroupException(string name)
        {
            name = name;
        }
    }
}