﻿namespace TodoListWAuthApi.DTOs.User;

public class UserLoginDto
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}