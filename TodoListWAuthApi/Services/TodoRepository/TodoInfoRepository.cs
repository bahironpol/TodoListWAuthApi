using Microsoft.EntityFrameworkCore;
using TodoListWAuthApi.Context;
using TodoListWAuthApi.Entities;

namespace TodoListWAuthApi.Services.TodoRepository;

public class TodoInfoRepository : ITodoInfoRepository
{
    private readonly TodoContext _context;

    public TodoInfoRepository(TodoContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Todo>> GetTodosAsync()
    {
        return await _context.Todos.ToListAsync();
    }

    public async Task<Todo> GetTodoAsync(int id)
    {
        return await _context.Todos.FindAsync(id);
    }

    public async Task<int> CreateTodoAsync(Todo todo)
    {
        await _context.Todos.AddAsync(todo);
        await _context.SaveChangesAsync();
        return todo.Id;
    }

    public async Task UpdateTodoAsync(Todo todo)
    {
        _context.Entry(todo).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTodoAsync(Todo todo)
    {
        _context.Todos.Remove(todo);
        await _context.SaveChangesAsync();
    }
    
    public async Task<bool> TodoExistAsync(int id)
    {
        return await _context.Todos.AnyAsync(T => T.Id == id);
    }
}