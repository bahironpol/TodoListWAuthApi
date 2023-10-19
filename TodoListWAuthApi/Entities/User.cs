namespace TodoListWAuthApi.Entities;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Password { get; set; } = null!;
    public List<Todo> Todos { get; set; } = new List<Todo>();
}