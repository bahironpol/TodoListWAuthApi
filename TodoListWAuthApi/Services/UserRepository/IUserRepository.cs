using TodoListWAuthApi.DTOs.User;
using TodoListWAuthApi.Entities;

namespace TodoListWAuthApi.Services.UserRepository;

public interface IUserRepository
{
    Task<int> Register(User registerinfo);
    Task<User> Login(UserLoginDto loginInfo);
}