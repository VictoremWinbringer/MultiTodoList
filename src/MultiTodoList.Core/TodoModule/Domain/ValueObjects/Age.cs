namespace MultiTodoList.Core.TodoModule.Domain.ValueObjects
{
    public struct Age
    {
        public uint Value { get; }

        public Age(uint value)
        {
            Value = value;
        }
    }
}