using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using MultiTodoList.Core.TodoModule.Domain;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;

namespace MultiTodoList.Application.Infrastructure.Dto
{
    [Table("TodoGroups")]
    public class TodoGroupDbDto
    {
        [Key] public string Name { get; set; }
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }
        public UserDbDto User { get; set; }
        public List<TodoDbDto> Todos { get; set; }

        public TodoGroup To()
        {
            return new TodoGroup(new Name(Name), new Color(Red, Green, Blue), Todos.Select(t => t.To()).ToList());
        }

        public static TodoGroupDbDto From(TodoGroup group, User user)
        {
            return new TodoGroupDbDto
            {
                Name = group.Name.Value,
                Blue = group.Color.Blue,
                Green = group.Color.Green,
                Red = group.Color.Red,
                Todos = group.Todos.Select(t => TodoDbDto.From(t, group, user)).ToList(),
                User = UserDbDto.From(user)
            };
        }
    }
}