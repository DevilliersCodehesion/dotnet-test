using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_grad.Dtos.Response
{
  public class UserResponseDto
  {

    public UserResponseDto(string name, string surname, string fullName, string email)
    {
      Name = name;
      Surname = surname;
      FullName = fullName;
      Email = email;
    }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
  }
}