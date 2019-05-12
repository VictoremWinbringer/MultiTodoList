using System;
using System.Collections.Generic;
using System.Linq;
using MultiTodoList.Core.TodoModule.Domain.Exceptions;

namespace MultiTodoList.Core.TodoModule.Domain
{
    public sealed class TodoGroup
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
}