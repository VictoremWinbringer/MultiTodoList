using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using MultiTodoList.Core.TodoModule.Domain.Exceptions;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;

namespace MultiTodoList.Core.TodoModule.Domain
{
    public sealed class User
    {
        private readonly List<TodoGroup> _groups = new List<TodoGroup>();

        public Guid Id { get; }
        public byte[] Photo { get; }
        public uint Age { get; }
        public Name Name { get; }
        public IReadOnlyCollection<TodoGroup> Groups => _groups.AsReadOnly();


        private void CheckColor(TodoGroup group)
        {
            if (_groups.Any(g => g.Color == @group.Color))
                throw new UserHaveGroupWithThisColorException(@group.Color);
        }

        private void CheckName(TodoGroup group)
        {
            if (_groups.Any(g => g.Name == @group.Name))
                throw new UserHaveGroupWithThisNameException(@group.Name);
        }

        private void CheckName(Todo todo)
        {
            if (_groups.Any(g => g.Todos.Any(t => t.Name == todo.Name)))
                throw new UserHaveTodoWithThisNameException(todo.Name);
        }

        public void Add(Todo todo, Guid groupId)
        {
            var group = _groups.FirstOrDefault(g => g.Id == groupId);

            if (group == null)
                throw new UserDontHaveGroupException(groupId);

            CheckName(todo);

            group.AddTodo(todo);
        }

        public void Add(TodoGroup group)
        {
            CheckName(group);

            CheckColor(group);

            _groups.Add(group);
        }

        public void Remove(TodoGroup group) => _groups.RemoveAll(g => g.Id == group.Id);

        public void Remove(Todo todo) => _groups.ForEach(g => g.RemoveTodo(todo));

        public void Update(TodoGroup group)
        {
            foreach (var oldGroup in _groups.Where(g => g.Id == group.Id))
            {
                if (oldGroup.Name != group.Name)
                {
                    CheckName(group);
                    oldGroup.Rename(group.Name);
                }

                if (oldGroup.Color != group.Color)
                {
                    CheckColor(group);
                    oldGroup.ChangeColor(group.Color);
                }
            }
        }

        public void Update(Todo todo)
        {
            foreach (var oldTodo in _groups.SelectMany(g => g.Todos).Where(t => t.Id == todo.Id))
            {
                if (oldTodo.Name != todo.Name)
                {
                    CheckName(todo);
                    oldTodo.Rename(todo.Name);
                }

                if (todo.IsComplite && !oldTodo.IsComplite)
                    oldTodo.MakeCompleted();
            }
        }
    }
}