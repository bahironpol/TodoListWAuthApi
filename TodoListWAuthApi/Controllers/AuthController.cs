using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TodoListWAuthApi.DTOs.User;
using TodoListWAuthApi.Entities;
using TodoListWAuthApi.Services.UserRepository;

namespace TodoListWAuthApi.Controllers;

[Route("api/authorization")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;
    
    public AuthController(IUserRepository userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;
    }

    [HttpPost("register")]
    public async Task<ActionResult> Register(UserRegisterDto userregisterinfo)
    {
        var userToRegister = new User
        {
            Name = userregisterinfo.Name,
            Email = userregisterinfo.Email,
            Password = userregisterinfo.Password,
        };
        await _userRepository.Register(userToRegister);
        return Ok();
    }
    
    [HttpPost("login")]
    public async Task<ActionResult> Login(UserLoginDto userlogininfo)
    {
        User user = await _userRepository.Login(userlogininfo);
        if (user == null)
        {
            return NotFound();
        }
        string token = CreateToken(user);
        
        return Ok(token);
    }
    
    private string CreateToken(User user)
    {
        List<Claim> claims = new List<Claim>()
        {
            new (ClaimTypes.NameIdentifier, user.Id.ToString()),
            new (ClaimTypes.Name, user.Name)
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:TokenKey").Value!));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(1),
            signingCredentials: credentials
        );
        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return jwt;
    }
}