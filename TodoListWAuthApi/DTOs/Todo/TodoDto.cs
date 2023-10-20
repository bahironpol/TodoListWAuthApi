using TodoListWAuthApi.Entities;

namespace TodoListWAuthApi.DTOs.Todo;

public class TodoDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public TodoCompletionState CompletionState { get; set; }
}