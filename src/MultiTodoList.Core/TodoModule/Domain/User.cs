using System;
using System.Collections.Generic;
using System.Linq;
using MultiTodoList.Core.TodoModule.Domain.Exceptions;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;

namespace MultiTodoList.Core.TodoModule.Domain
{
    public sealed class User
    {
        private readonly List<TodoGroup> _groups;

        public Guid Id { get; }
        public Photo Photo { get; private set; }
        public Age Age { get; private set; }
        public Name Name { get; private set; }
        
        public IReadOnlyCollection<TodoGroup> Groups => _groups.AsReadOnly();

        public User(Guid id, Photo photo, Age age, Name name, List<TodoGroup> groups)
        {
            Id = id;
            Photo = photo;
            Age = age;
            Name = name;
            _groups = groups;
        }

        public User(Photo photo,Age age, Name name) : this(Guid.NewGuid(), photo, age, name, new List<TodoGroup>()){}

        private void CheckName(TodoGroup group)
        {
            if (_groups.Any(g => g.Name == group.Name))
                throw new UserHaveGroupWithThisNameException(@group.Name);
        }
        
        public void Add(TodoGroup group)
        {
            CheckName(group);

            _groups.Add(group);
        }

        public void RemoveGroup(Name groupName) => _groups.RemoveAll(g => g.Name == groupName);

        public void UpdateInfo(Photo photo, Name name, Age age)
        {
            Photo = photo;
            Name = name;
            Age = age;
        }
    }
}