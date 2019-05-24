using System.Collections.Generic;
using System.Linq;
using MultiTodoList.Core.TodoModule.Domain;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;

namespace MultiTodoList.Application.Presentation.Models
{
    public class TodoGroupModel
    {
        public string Name { get; set; }
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }
        public List<TodoModel> Todos { get; set; }

        public TodoGroup To()
        {
            return new TodoGroup(new Name(Name), new Color(Red, Green, Blue), Todos.Select(t => t.To()).ToList());
        }

        public static TodoGroupModel From(TodoGroup group)
        {
            return new TodoGroupModel
            {
                Name = group.Name.Value,
                Blue = group.Color.Blue,
                Green = group.Color.Green,
                Red = group.Color.Red,
                Todos = group.Todos.Select(TodoModel.From).ToList()
            };
        }
    }
}