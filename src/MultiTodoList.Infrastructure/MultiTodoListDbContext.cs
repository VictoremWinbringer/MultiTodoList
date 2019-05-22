using Microsoft.EntityFrameworkCore;
using MultiTodoList.Core.TodoModule.Domain;
using MultiTodoList.Infrastructure.Dto;

namespace MultiTodoList.Infrastructure
{
    public class MultiTodoListDbContext : DbContext
    {
        public MultiTodoListDbContext(DbContextOptions<MultiTodoListDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoDbDto>()
                .HasOne(t => t.Group)
                .WithMany(g => g.Todos)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<TodoGroupDbDto>()
                .HasOne(g => g.User)
                .WithMany(u => u.Groups)
                .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserDbDto> Users { get; set; }
        public DbSet<TodoGroupDbDto> TodoGroups { get; set; }
        public DbSet<TodoDbDto> Todos { get; set; }
    }
}