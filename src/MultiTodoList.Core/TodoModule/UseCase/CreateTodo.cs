using System;
using System.Linq;
using MultiTodoList.Core.TodoModule.Domain;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;

namespace MultiTodoList.Core.TodoModule.UseCase
{
    public class CreateTodo
    {
        private readonly IUserRepository _repository;

        public CreateTodo(IUserRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Name todoName, Guid userId, Name groupName)
        {
            if (_repository.Contains(todoName))
                throw new TodoExistsException();

            var user = _repository.Get(userId);
            var group = user.Groups.FirstOrDefault(g => g.Name == groupName);
            group.AddTodo(new Todo(todoName));
            _repository.Update(user);
        }
    }

    public class TodoExistsException : Exception
    {
    }

    public class MakeCompletedTodo
    {
        private readonly IUserRepository _repository;

        public MakeCompletedTodo(IUserRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Name todoName, Guid userId, Name groupName)
        {
            var user = _repository.Get(userId);
            var group = user.Groups.FirstOrDefault(g => g.Name == groupName);
            var todo = group.Todos.FirstOrDefault(t => t.Name == todoName);
            todo.MakeCompleted();
            _repository.Update(user);
        }
    }

    public class RemoveTodo
    {
        private readonly IUserRepository _repository;

        public RemoveTodo(IUserRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Name todoName, Guid userId, Name groupName)
        {
            var user = _repository.Get(userId);
            var group = user.Groups.FirstOrDefault(g => g.Name == groupName);
            group.RemoveTodo(todoName);
            _repository.Update(user);
        }
    }


    public class CreateGroup
    {
        private readonly IUserRepository _repository;

        public CreateGroup(IUserRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid userId, Name groupName, Color groupColor)
        {
            var user = _repository.Get(userId);
            var group = new TodoGroup(groupName, groupColor);
            user.Add(group);
            _repository.Update(user);
        }
    }

    public class ChangeGroupColor
    {
        private readonly IUserRepository _repository;

        public ChangeGroupColor(IUserRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid userId, Name groupName, Color groupColor)
        {
            var user = _repository.Get(userId);
            var group = user.Groups.FirstOrDefault(g => g.Name == groupName);
            group.ChangeColor(groupColor);
            _repository.Update(user);
        }
    }

    public class RemoveGroup
    {
        private readonly IUserRepository _repository;

        public RemoveGroup(IUserRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid userId, Name groupName)
        {
            var user = _repository.Get(userId);
            user.RemoveGroup(groupName);
            _repository.Update(user);
        }
    }
}