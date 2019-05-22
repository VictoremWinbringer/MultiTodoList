using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MultiTodoList.Core.TodoModule.Domain;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;

namespace MultiTodoList.Infrastructure
{
    [Table("Todos")]
    public class TodoDbDto
    {
        [Key] public string Name { get; set; }
        public bool IsComplited { get; set; }
        public DateTime Created { get; set; }
        public DateTime Complited { get; set; }

        public Todo To()
        {
            return new Todo(new Name(Name), IsComplited, Created, Complited);
        }

        public static TodoDbDto From(Todo todo)
        {
            return new TodoDbDto
            {
                Name = todo.Name.Value,
                IsComplited = todo.IsComplited,
                Created = todo.Created,
                Complited = todo.Complited,
            };
        }
    }
}