using System;
using MultiTodoList.Core.TodoModule.Domain.Exceptions;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;

namespace MultiTodoList.Core.TodoModule.Domain
{
    public sealed class Todo
    {
        // name is id
        public Name Name { get; }
        public bool IsComplited { get; private set; }
        public DateTime Created { get; }
        public DateTime Complited { get; private set; }

        public Todo(Name name, bool isComplited, DateTime created, DateTime complited)
        {
            if (complited != default && complited < created)
                throw new TodoPreviouslyCompletedThanCreatedException(created, complited);
            Name = name;
            IsComplited = isComplited;
            Created = created;
        }

        public Todo(Name name) : this(name, default, DateTime.UtcNow, default)
        {
        }

        internal void MakeCompleted()
        {
            if (IsComplited)
                throw new TodoAlreadyCompletedException();

            IsComplited = true;
            Complited = DateTime.UtcNow;
        }
    }
}