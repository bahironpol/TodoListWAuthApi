using TodoListWAuthApi.Entities;

namespace TodoListWAuthApi.DTOs.Todo;

public class TodoForCreationDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public TodoCompletionState CompletionState { get; set; }
}