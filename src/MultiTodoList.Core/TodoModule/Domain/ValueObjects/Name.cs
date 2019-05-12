using System;
using System.Text.RegularExpressions;
using MultiTodoList.Core.TodoModule.Domain.Exceptions;

namespace MultiTodoList.Core.TodoModule.Domain.ValueObjects
{
    public sealed class Name
    {
        public string Value { get; }

        public Name(string value)
        {
            if(string.IsNullOrWhiteSpace(value))
                throw new NameIsEmptyException();
            
            if(!Regex.IsMatch(value,"\\w+"))
                throw new NameFormatException(value);
                
            Value = value;
        }
        
        public static bool operator ==(Name lhs, Name rhs)
        {
            return lhs.Value.Equals(rhs.Value, StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool operator !=(Name lhs, Name rhs) => !(lhs == rhs);
    }
}