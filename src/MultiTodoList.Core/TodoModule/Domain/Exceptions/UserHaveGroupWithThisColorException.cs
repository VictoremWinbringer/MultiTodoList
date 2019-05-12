using System;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;

namespace MultiTodoList.Core.TodoModule.Domain.Exceptions
{
    public sealed class UserHaveGroupWithThisColorException : Exception
    {
        public Color Color { get; }
        public UserHaveGroupWithThisColorException(Color color)
        {
            Color = color;
        }
    }
}