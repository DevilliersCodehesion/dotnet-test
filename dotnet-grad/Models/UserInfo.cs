using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_grad.Dtos.Response;

namespace dotnet_grad.Models
{
  public class UserInfo
  {
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public UserInfoResponseDto ToDto(UserInfo userInfo)
    {
      return new UserInfoResponseDto(userInfo);
    }
  }
}