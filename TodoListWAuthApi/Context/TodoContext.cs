using Microsoft.EntityFrameworkCore;
using TodoListWAuthApi.Entities;

namespace TodoListWAuthApi.Context;

public class TodoContext : DbContext
{
    public DbSet<Todo> Todos { get; set; }
    public DbSet<User> Users { get; set; }

    public TodoContext(DbContextOptions<TodoContext> options) : base(options)
    {
        
    }
}