﻿using System;
using System.Collections.Generic;
using System.Linq;
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

    public struct Color
    {
        public byte Red { get; }
        public byte Green { get; }
        public byte Blue { get; }

        public Color(byte red, byte green, byte blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }
    }

    public class TodoPreviouslyCompletedThanCreatedException : Exception
    {
        public DateTime Created { get; }
        public DateTime Complited { get; }

        public TodoPreviouslyCompletedThanCreatedException(DateTime created, DateTime complited)
        {
            Created = created;
            Complited = complited;
        }
    }
    
    public class Todo
    {
        public Guid Id { get; }
        public Name Name { get; private set; }
        public bool IsComplite { get; private set; }
        public DateTime Created { get; }
        public DateTime Complited { get; private set; }

        public Todo(Guid id, Name name, bool isComplite, DateTime created, DateTime complited)
        {
            
            if(complited != default && complited < created)
                throw new TodoPreviouslyCompletedThanCreatedException(created,complited);
            
            Id = id;
            Name = name;
            IsComplite = isComplite;
            Created = created;
        }
        
        public Todo(Name name) : this(Guid.NewGuid(), name, default, DateTime.UtcNow, default)
        {
            
        }

        internal void MakeCompleted()
        {
            IsComplite = true;
            Complited = DateTime.UtcNow;
        }

        internal void Rename(Name name)
        {
            Name = name;
        }
    }

    public class TodoExistInGroupException : Exception
    {
        public Guid Id { get; }

        public TodoExistInGroupException(Guid id)
        {
            Id = id;
        }
    }

    public class TodoGroup
    {
        private readonly List<Todo> _todos;
        
        public Guid Id { get;}
        public Name Name { get; private set; }
        public Color Color { get; private set; }
        public IReadOnlyCollection<Todo> Todos => _todos.AsReadOnly();

        public TodoGroup(Guid id, Name name, Color color, List<Todo> todos)
        {
            Id = id;
            Name = name;
            Color = color;
            _todos = todos;
        }

        public TodoGroup(Name name, Color color):this(Guid.NewGuid(), name, color, new List<Todo>())
        {
            
        }

        internal void Rename(Name name)
        {
            Name = name;
        }

        internal void ChangeColor(Color color)
        {
            Color = color;
        }

        internal void AddTodo(Todo todo)
        {
            if(_todos.Any(t=>t.Id == todo.Id))
                throw new TodoExistInGroupException(todo.Id);
           _todos.Add(todo);
        }

        internal void RemoveTodo(Todo todo)
        {
            _todos.RemoveAll(t => t.Id == todo.Id);
        }
    }
    
    public class User
    {
        private readonly List<TodoGroup> _groups = new List<TodoGroup>();
        
        public Guid Id { get; }
        public  byte[] Photo { get; }
        public uint Age { get; }
        public Name Name { get;}
        public IReadOnlyCollection<TodoGroup> Groups => _groups.AsReadOnly();
    }
}