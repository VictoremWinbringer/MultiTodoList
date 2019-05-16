using System;
using System.Collections.Generic;
using System.Linq;
using MultiTodoList.Core.TodoModule.Domain.Exceptions;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;

namespace MultiTodoList.Core.TodoModule.Domain
{
    public sealed class TodoGroup
    {
        private readonly List<Todo> _todos;

        //Name is ID
        public Name Name { get; }

        public Color Color { get; private set; }
        
        public IReadOnlyCollection<Todo> Todos => _todos.AsReadOnly();

        public TodoGroup(Name name, Color color, List<Todo> todos)
        {
            Name = name;
            Color = color;
            _todos = todos;
        }

        public TodoGroup(Name name, Color color) : this(name, color, new List<Todo>())
        {
        }

        internal void AddTodo(Todo todo)
        {
            if (_todos.Any(t => t.Name == todo.Name))
                throw new TodoExistInGroupException(todo.Name.Value);
            _todos.Add(todo);
        }

        internal void RemoveTodo(Name todoName)
        {
            _todos.RemoveAll(t => t.Name == todoName);
        }

        internal void ChangeColor(Color color)
        {
            Color = color;
        }
    }
}