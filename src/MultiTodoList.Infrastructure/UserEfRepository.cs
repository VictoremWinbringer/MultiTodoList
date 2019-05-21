using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MultiTodoList.Core.TodoModule.Domain;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;
using MultiTodoList.Core.TodoModule.UseCase;
using Remotion.Linq.Clauses;

namespace MultiTodoList.Infrastructure
{
    [Table("Users")]
    class UserDbDto
    {
        [Key] public Guid Id { get; set; }
        public byte[] Photo { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
    }

    [Table("Todos")]
    class TodoDbDto
    {
        [Key] public string Name { get; }
        public bool IsComplited { get; set; }
        public DateTime Created { get; set; }
        public DateTime Complited { get; set; }
        public UserDbDto User { get; set; }
        public TodoGroupDbDto TodoGroup { get; set; }
    }

    [Table("TodoGroups")]
    class TodoGroupDbDto
    {
        [Key] public string Name { get; set; }

        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }

        public TodoGroup To(List<Todo> todos)
        {
            return new TodoGroup(new Name(Name), new Color(Red, Green, Blue), todos);
        }

        public static TodoGroupDbDto From(TodoGroup group)
        {
            return new TodoGroupDbDto
            {
                Name = group.Name.Value,
                Blue = group.Color.Blue,
                Green = group.Color.Green,
                Red = group.Color.Red
            };
        }
    }

    public class UserEfRepository : IUserRepository
    {
        private readonly DbSet<User> _users;

        public UserEfRepository(DbSet<User> users)
        {
            _users = users;
        }

        public void Create(User user)
        {
            _users.Add(user);
        }

        public User Get(Guid id)
        {
            return _users.First(u => u.Id == id);
        }

        public List<User> Get()
        {
            return _users.ToList();
        }

        public void Update(User user)
        {
            _users.Update(user);
        }

        public void Remove(Guid id)
        {
            var user = _users.Find(id);
            _users.Remove(user);
        }

        public bool Contains(Name todoName)
        {
            return _users.Any(u => u.Groups.Any(g => g.Todos.Any(t => t.Name == todoName)));
        }
    }
}