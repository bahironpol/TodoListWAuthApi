namespace TodoListWAuthApi.Entities;

public enum TodoCompletionState
{
    Started = 1,
    Pending = 2,
}

public class Todo
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public TodoCompletionState CompletionState { get; set; }
    public User User { get; set; } = null!;
}