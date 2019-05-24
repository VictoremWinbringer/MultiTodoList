using System;
using MultiTodoList.Core.TodoModule.Domain;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;

namespace MultiTodoList.Application.Presentation.Models
{
    public class TodoModel
    {
        public string Name { get; set; }
        public bool IsComplited { get; set; }
        public DateTime Created { get; set; }
        public DateTime Complited { get; set; }

        public Todo To()
        {
            return new Todo(new Name(Name), IsComplited, Created, Complited);
        }

        public static TodoModel From(Todo todo)
        {
            return new TodoModel
            {
                Name = todo.Name.Value,
                IsComplited = todo.IsComplited,
                Created = todo.Created,
                Complited = todo.Complited,
            };
        }
    }
}