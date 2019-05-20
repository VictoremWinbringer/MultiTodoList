using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MultiTodoList.Core.TodoModule.Domain;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;
using MultiTodoList.Core.TodoModule.UseCase;

namespace MultiTodoList.Infrastructure
{
    [Table("Users")]
    class UserDbDto
    {
    }

    [Table("Todos")]
    class TodoDbDto
    {
        [Key]
        public string Name { get; }
        public bool IsComplited { get; set; }
        public DateTime Created { get; set; }
        public DateTime Complited { get; set; }
        public UserDbDto User { get; set; }
        public TodoGroupDbDto TodoGroup { get; set; }
    }

    [Table("TodoGroups")]
    class TodoGroupDbDto
    {
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