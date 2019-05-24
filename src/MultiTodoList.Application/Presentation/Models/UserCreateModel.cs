using MultiTodoList.Core.TodoModule.Domain;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;

namespace MultiTodoList.Application.Presentation.Models
{
    public class UserCreateModel
    {
        public byte[] Photo { get; set; }
        public uint Age { get; set; }
        public string Name { get; set; }
        
        public User To()
        {
            return new User(new Photo(Photo),new Age(Age),new Name(Name));
        }
    }
}