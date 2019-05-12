using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MultiTodoList.Core
{
   public class NameIsEmptyException:Exception
    {
        
    }

   public class NameFormatException : Exception
   {
       public string Name { get; }

       public NameFormatException(string name)
       {
           Name = name;
       }
   }
   
    public class Name
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
    }
    
    public class Todo
    {
        public Guid Id { get; }
        public Name Name { get; }
        public bool IsComplite { get; }
        public DateTime Created { get; }
    }

    public class TodoGroup
    {
        private readonly List<Todo> _todos = new List<Todo>();
        
        public Guid Id { get;}
        public Name Name { get; }
       
    }
    public class User
    {
        private readonly List<TodoGroup> _groups = new List<TodoGroup>();
        
        public Guid Id { get; }
        public  byte[] Photo { get; }
        public uint Age { get; }
        public Name Name { get;}
        
    }
}