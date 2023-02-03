using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using dotnet_grad.Dtos.Request;
using dotnet_grad.Dtos.Response;
using dotnet_grad.Interface;
using dotnet_grad.Models;
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
    public async Task<ActionResult<IEnumerable<UserInfoResponseDto>>> getUserInfo()
    {
      List<UserInfo> users = await _tokenRepository.getUserInfo();
      IEnumerable<UserInfoResponseDto> dto = users.Select(x => new UserInfoResponseDto(x.Email));
      return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateToken([FromBody] UserInfo _userInfo)
    {
      if (_userInfo != null && _userInfo.Password != null && _userInfo.Email != null)
      {
        var user = await _tokenRepository.getUserToken(_userInfo.Email, _userInfo.Password);
        if (user != null)
        {
          var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            new Claim("UserId", user.Id.ToString()),
            new Claim("DisplayName", user.Email),
            new Claim("Email", user.Email),
            new Claim (ClaimTypes.Role, user.Role)
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
    public async Task<ActionResult<UserInfoResponseDto>> createUserInfo([FromBody] UserInfo userInfo)
    {
      UserInfo createdUser = await _tokenRepository.addUserInfo(userInfo);
      return new UserInfoResponseDto(createdUser);
    }

  }
}