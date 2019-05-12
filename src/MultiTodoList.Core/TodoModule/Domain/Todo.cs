using System;
using MultiTodoList.Core.TodoModule.Domain.Exceptions;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;

namespace MultiTodoList.Core.TodoModule.Domain
{
    public sealed class Todo
    {
        public Guid Id { get; }
        public Name Name { get; private set; }
        public bool IsComplite { get; private set; }
        public DateTime Created { get; }
        public DateTime Complited { get; private set; }

        public Todo(Guid id, Name name, bool isComplite, DateTime created, DateTime complited)
        {
            
            if(complited != default && complited < created)
                throw new TodoPreviouslyCompletedThanCreatedException(created,complited);
            
            Id = id;
            Name = name;
            IsComplite = isComplite;
            Created = created;
        }
        
        public Todo(Name name) : this(Guid.NewGuid(), name, default, DateTime.UtcNow, default)
        {
            
        }

        internal void MakeCompleted()
        {
            IsComplite = true;
            Complited = DateTime.UtcNow;
        }

        internal void Rename(Name name)
        {
            Name = name;
        }
    }
}