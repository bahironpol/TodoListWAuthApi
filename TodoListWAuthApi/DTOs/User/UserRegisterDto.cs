namespace TodoListWAuthApi.DTOs.User;

public class UserRegisterDto
{
    public string Email { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Password { get; set; } = null!;
}