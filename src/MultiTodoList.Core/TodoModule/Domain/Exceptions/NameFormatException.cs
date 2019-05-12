using System;

namespace MultiTodoList.Core.TodoModule.Domain.Exceptions
{
    public sealed class NameFormatException : Exception
    {
        public string Name { get; }

        public NameFormatException(string name)
        {
            Name = name;
        }
    }
}