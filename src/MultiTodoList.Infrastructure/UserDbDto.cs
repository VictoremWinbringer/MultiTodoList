using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using MultiTodoList.Core.TodoModule.Domain;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;

namespace MultiTodoList.Infrastructure
{
    [Table("Users")]
    public class UserDbDto
    {
        [Key] public Guid Id { get; set; }
        public byte[] Photo { get; set; }
        public uint Age { get; set; }
        public string Name { get; set; }

        public List<TodoGroupDbDto> Groups { get; set; }

        public User To()
        {
            return new User(Id, new Photo(Photo), new Age(Age), new Name(Name), Groups.Select(g => g.To()).ToList());
        }

        public static UserDbDto From(User user)
        {
            return new UserDbDto
            {
                Id = user.Id,
                Age = user.Age.Value,
                Name = user.Name.Value,
                Photo = user.Photo.Value,
                Groups = user.Groups.Select(TodoGroupDbDto.From).ToList()
            };
        }
    }
}