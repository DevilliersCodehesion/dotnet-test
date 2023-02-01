using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_grad.Models;

namespace dotnet_grad.Dtos.Response
{
  public class UserInfoResponseDto
  {
    public UserInfoResponseDto(UserInfo userInfo)
    {
      Email = userInfo.Email;
    }

    public UserInfoResponseDto(string email)
    {
      Email = email;
    }

    public string Email { get; set; }
  }
}