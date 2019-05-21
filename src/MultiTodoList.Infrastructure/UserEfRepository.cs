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
        public uint Age { get; set; }
        public string Name { get; set; }
        
        public List<TodoGroupDbDto> Groups { get; set; }

        public User To()
        {
            return new User(Id,new Photo(Photo),new Age(Age),new Name(Name), Groups.Select(g=>g.To()).ToList());
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

    [Table("Todos")]
   public class TodoDbDto
    {
        [Key] public string Name { get; set; }
        public bool IsComplited { get; set; }
        public DateTime Created { get; set; }
        public DateTime Complited { get; set; }
        
        public Todo To()
        {
            return new Todo(new Name(Name),IsComplited, Created, Complited);
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

   public class MultiTodoListDbContext : DbContext
   {
       public DbSet<UserDbDto> Users { get; set; }
   }

    [Table("TodoGroups")]
    class TodoGroupDbDto
    {
        [Key] public string Name { get; set; }
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }
        public List<TodoDbDto> Todos { get; set; }

        public TodoGroup To()
        {
            return new TodoGroup(new Name(Name), new Color(Red, Green, Blue), Todos.Select(t=>t.To()).ToList());
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

    public class UserEfRepository : IUserRepository
    {
        private readonly MultiTodoListDbContext _usersContext;

        public UserEfRepository(MultiTodoListDbContext usersContext)
        {
            _usersContext = usersContext;
        }

        public void Create(User user)
        {
            _usersContext.Users.Add(UserDbDto.From(user));
            _usersContext.SaveChanges();
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