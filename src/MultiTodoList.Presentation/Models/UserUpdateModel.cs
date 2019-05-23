using System;
using System.Collections.Generic;
using MultiTodoList.Core.TodoModule.Domain;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;

namespace MultiTodoList.Presentation.Models
{
    public class UserUpdateModel
    {
        public Guid Id { get; set; }
        public byte[] Photo { get; set; }
        public uint Age { get; set; }
        public string Name { get; set; }
        public byte[] RowVersion { get; set; }
        
        public User To()
        {
            return new User(Id, new Photo(Photo), new Age(Age), new Name(Name), new List<TodoGroup>(), RowVersion);
        }
    }
}