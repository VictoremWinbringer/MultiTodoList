namespace MultiTodoList.Core.TodoModule.Domain.ValueObjects
{
    public struct Color
    {
        public byte Red { get; }
        public byte Green { get; }
        public byte Blue { get; }

        public Color(byte red, byte green, byte blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        public static bool operator ==(Color lhs, Color rhs)
        {
            return lhs.Blue == rhs.Blue &&
                   lhs.Green == rhs.Green &&
                   lhs.Red == rhs.Red;
        }

        public static bool operator !=(Color lhs, Color rhs) => !(lhs == rhs);
    }
}