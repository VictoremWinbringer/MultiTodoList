using System;

namespace MultiTodoList.Core.TodoModule.Domain.Exceptions
{
    public sealed class TodoPreviouslyCompletedThanCreatedException : Exception
    {
        public DateTime Created { get; }
        public DateTime Complited { get; }

        public TodoPreviouslyCompletedThanCreatedException(DateTime created, DateTime complited)
        {
            Created = created;
            Complited = complited;
        }
    }
}