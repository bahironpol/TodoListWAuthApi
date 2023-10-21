using System.ComponentModel.DataAnnotations;

namespace TodoListWAuthApi.Entities;

public class User
{
    public int Id { get; set; }
    [Required] [EmailAddress] [MinLength(8)] [MaxLength(30)]
    public string Email { get; set; } = null!;
    [Required] [MinLength(8)] [MaxLength(30)]
    public string Name { get; set; } = null!;
    [Required] [MinLength(8)] [MaxLength(30)]
    public string Password { get; set; } = null!;
    
    public List<Todo> Todos { get; set; } = new List<Todo>();
}