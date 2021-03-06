﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MultiTodoList.Application.Infrastructure.Dto;
using MultiTodoList.Core.TodoModule.Domain;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;
using MultiTodoList.Core.TodoModule.UseCase;

namespace MultiTodoList.Application.Infrastructure
{
    public class UserEfRepository : IUserRepository
    {
        private readonly MultiTodoListDbContext _usersContext;

        public UserEfRepository(MultiTodoListDbContext usersContext)
        {
            _usersContext = usersContext;
        }

        public Task Create(User user)
        {
            _usersContext.Users.Add(UserDbDto.From(user));
          return  _usersContext.SaveChangesAsync();
        }

        public async Task< User> Get(Guid id)
        {
            var user = await _usersContext
                .Users
                .Include(u =>u.Groups)
                .ThenInclude(g=>g.Todos)
                .FirstAsync(u => u.Id == id);
            return user.To();
        }

        public async Task<List<User>> Get()
        {
            var users = await _usersContext
                .Users
                .Include(u =>u.Groups)
                .ThenInclude(g=>g.Todos)
                .ToListAsync();
            return users.Select(u => u.To()).ToList();
        }

        public Task Update(User user)
        {
            _usersContext.Users.Update(UserDbDto.From(user));
          return  _usersContext.SaveChangesAsync();
        }

        public Task Remove(Guid id)
        {
            var user = _usersContext.Users.Find(id);
            _usersContext.Users.Remove(user);
           return _usersContext.SaveChangesAsync();
        }

        public Task<bool> Contains(Name todoName)
        {
            var name = todoName.Value;
            return _usersContext.Todos.AnyAsync(t => t.Name == name);
        }
    }
}