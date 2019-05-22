using Microsoft.EntityFrameworkCore;

namespace MultiTodoList.Infrastructure
{
    public class MultiTodoListDbContext : DbContext
    {
        public DbSet<UserDbDto> Users { get; set; }
        public DbSet<TodoGroupDbDto> TodoGroups { get; set; }
        public DbSet<TodoDbDto> Todos { get; set; }
    }
}