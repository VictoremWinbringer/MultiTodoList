using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using MultiTodoList.Core.TodoModule.Domain;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;

namespace MultiTodoList.Infrastructure
{
    [Table("TodoGroups")]
    public class TodoGroupDbDto
    {
        [Key] public string Name { get; set; }
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }
        public List<TodoDbDto> Todos { get; set; }

        public TodoGroup To()
        {
            return new TodoGroup(new Name(Name), new Color(Red, Green, Blue), Todos.Select(t => t.To()).ToList());
        }

        public static TodoGroupDbDto From(TodoGroup group)
        {
            return new TodoGroupDbDto
            {
                Name = group.Name.Value,
                Blue = group.Color.Blue,
                Green = group.Color.Green,
                Red = group.Color.Red,
                Todos = group.Todos.Select(TodoDbDto.From).ToList()
            };
        }
    }
}