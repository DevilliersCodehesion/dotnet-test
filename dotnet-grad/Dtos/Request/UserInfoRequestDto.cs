using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace dotnet_grad.Dtos.Request
{
  public class UserInfoRequestDto
  {
    public UserInfoRequestDto(UserInfo userInfo)
    {
      Email = userInfo.Email;
      Password = userInfo.Password;
    }

    public UserInfoRequestDto(string email, string password)
    {
      Email = email;
      Password = password;
    }
    public string Email { get; set; }
    public string Password { get; set; }
  }
}