using MultiTodoList.Core.TodoModule.Domain.Exceptions;

namespace MultiTodoList.Core.TodoModule.Domain.ValueObjects
{
    public class Photo
    {
        public byte[] Value { get; }

        public Photo(byte[] value)
        {
            if (value == null)
                throw new PhotoNullException();

            if (value.Length == 0)
                throw new PhotoEmptyException();
            
            Value = value;
        }
    }
}