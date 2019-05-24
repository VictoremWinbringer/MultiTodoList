using System;
using System.Collections.Generic;
using System.Linq;
using MultiTodoList.Core.TodoModule.Domain;

namespace MultiTodoList.Application.Presentation.Models
{
    public class UserReadModel
    {
        public Guid Id { get; set; }
        public byte[] Photo { get; set; }
        public uint Age { get; set; }
        public string Name { get; set; }
        public List<TodoGroupModel> Groups { get; set; }
        public byte[] RowVersion { get; set; }
        
        public static UserReadModel From(User user)
        {
            return new UserReadModel
            {
                Id = user.Id,
                Age = user.Age.Value,
                Name = user.Name.Value,
                Photo = user.Photo.Value,
                Groups = user.Groups.Select(TodoGroupModel.From).ToList(),
                RowVersion = user.RowVersion
            };
        }
    }
}