using TodoListWAuthApi.DTOs.Todo;
using TodoListWAuthApi.Entities;

namespace TodoListWAuthApi.Services.TodoRepository;

public interface ITodoInfoRepository
{
    Task<IEnumerable<Todo>> GetTodosAsync();
    Task<Todo> GetTodoAsync(int id);
    Task<int> CreateTodoAsync(Todo todo);
    Task UpdateTodoAsync(Todo todo);
    Task DeleteTodoAsync(Todo todo);

    Task<bool> TodoExistAsync(int id);
}