using System.ComponentModel.DataAnnotations;

namespace TodoListWAuthApi.DTOs.User;

public class UserRegisterDto
{
    [EmailAddress] [Required]
    public string Email { get; set; } = null!;
    [Required] [MinLength(8)] [MaxLength(25)]
    public string Name { get; set; } = null!;
    [Required] [MinLength(8)] [MaxLength(25)]
    public string Password { get; set; } = null!;
}