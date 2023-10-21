using System.ComponentModel.DataAnnotations;

namespace TodoListWAuthApi.Entities;

public enum TodoCompletionState
{
    Started = 1,
    Pending = 2,
}

public class Todo
{
    public int Id { get; set; }
    [Required] [MinLength(4)] [MaxLength(25)]
    public string Name { get; set; } = null!;
    [Required] [MinLength(4)] [MaxLength(25)]
    public string Description { get; set; } = null!;
    [Required]
    public TodoCompletionState CompletionState { get; set; }
    [Required]
    public int UserId { get; set; }
    public User User { get; set; } = null!;
}