using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using dotnet_grad.Interface;
using dotnet_grad.Models;
using dotnet_grad.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace dotnet_grad.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class TokenController : ControllerBase
  {
    public IConfiguration _configuration;
    private readonly TestContext _testContext;
    private readonly IToken _tokenRepository;
    public TokenController(IConfiguration config, TestContext testContext, IToken tokenRepo)
    {
      _configuration = config;
      _testContext = testContext;
      _tokenRepository = tokenRepo;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserInfo>>> getUserInfo()
    {
      return await _tokenRepository.getUserInfo();
    }

    [HttpPost]
    public async Task<IActionResult> CreateToken([FromBody] UserInfo _userInfo)
    {
      if (_userInfo != null && _userInfo.password != null && _userInfo.email != null)
      {
        var user = await _tokenRepository.getUserToken(_userInfo.email, _userInfo.password);
        if (user != null)
        {
          var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            new Claim("UserId", user.Id.ToString()),
            new Claim("DisplayName", user.email),
            new Claim("Email", user.email),
          };

          var key = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
          var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
          var token = new JwtSecurityToken(
              _configuration["Jwt:Issuer"],
              _configuration["Jwt:Audience"],
              claims,
              expires: DateTime.UtcNow.AddMinutes(10),
              signingCredentials: signIn
          );

          return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
      }
      return BadRequest("Invalid credentials");
    }

    [HttpPost("addUserInfo")]
    public async Task<ActionResult<UserInfo>> createUserInfo([FromBody] UserInfo userInfo)
    {
      return await _tokenRepository.addUserInfo(userInfo);
    }

  }
}