using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TodoListWAuthApi.Context;
using TodoListWAuthApi.DTOs.User;
using TodoListWAuthApi.Entities;

namespace TodoListWAuthApi.Services.UserRepository;

public class UserRepository : IUserRepository
{
    private readonly TodoContext _context;


    public UserRepository(TodoContext context)
    {
        _context = context;
    }

    public async Task<int> Register(User registerinfo)
    {
        _context.Users.Add(registerinfo);
        await _context.SaveChangesAsync();
        return registerinfo.Id;
    }
    
    public async Task<User> Login(UserLoginDto loginInfo)
    {
        return await _context.Users.FirstOrDefaultAsync(u =>
            u.Email == loginInfo.Email && u.Password == loginInfo.Password);
    }

}