using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;

namespace MultiTodoList.Core
{
   public class NameIsEmptyException:Exception
    {
        
    }

   public class NameFormatException : Exception
   {
       public string Name { get; }

       public NameFormatException(string name)
       {
           Name = name;
       }
   }
   
    public class Name
    {
        public string Value { get; }

        public Name(string value)
        {
            if(string.IsNullOrWhiteSpace(value))
                throw new NameIsEmptyException();
            
            if(!Regex.IsMatch(value,"\\w+"))
                throw new NameFormatException(value);
                
            Value = value;
        }
    }

    public enum ColorField
    {
        Red,
        Green,
        Blue
    }

    public class ColorValueToBigException : Exception
    {
        public ColorField Field { get; }
        public uint Value { get; }

        public ColorValueToBigException(ColorField field, uint value)
        {
            Field = field;
            Value = value;
        }
    }

    public struct Color
    {
        public uint Red { get; }
        public uint Green { get; }
        public uint Blue { get; }

        public Color(uint red, uint green, uint blue)
        {
            if (red > 255)
                throw new ColorValueToBigException(ColorField.Red, red);
            
            if (green > 255)
                throw new ColorValueToBigException(ColorField.Green, green);
            
            if (blue > 255)
                throw new ColorValueToBigException(ColorField.Blue, blue);
            
            Red = red;
            Green = green;
            Blue = blue;
        }
    }
    
    public class Todo
    {
        public Guid Id { get; }
        public Name Name { get; }
        public bool IsComplite { get; }
        public DateTime Created { get; }
    }

    public class TodoGroup
    {
        private readonly List<Todo> _todos = new List<Todo>();
        
        public Guid Id { get;}
        public Name Name { get; }
        public Color Color { get; }
       
    }
    public class User
    {
        private readonly List<TodoGroup> _groups = new List<TodoGroup>();
        
        public Guid Id { get; }
        public  byte[] Photo { get; }
        public uint Age { get; }
        public Name Name { get;}
        
    }
}