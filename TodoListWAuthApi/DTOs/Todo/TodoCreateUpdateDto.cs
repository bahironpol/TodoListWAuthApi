using System.ComponentModel.DataAnnotations;
using TodoListWAuthApi.Entities;

namespace TodoListWAuthApi.DTOs.Todo;

public class TodoCreateUpdateDto
{
    [Required] [MinLength(4)] [MaxLength(25)]
    public string Name { get; set; } = null!;
    [Required] [MinLength(4)] [MaxLength(25)]
    public string Description { get; set; } = null!;
    [Required]
    public TodoCompletionState CompletionState { get; set; }
    [Required]
    public int UserId { get; set; }
}