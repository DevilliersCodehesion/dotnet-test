using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_grad.Dtos.Request
{
  public class UserRequestDto
  {
    public UserRequestDto(string name, string surname, string fullName, string email, string idNumber, string username)
    {
      Name = name;
      Surname = surname;
      FullName = fullName;
      Email = email;
      IdNumber = idNumber;
      Username = username;
    }

    public string Name { get; set; }
    public string Surname { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string IdNumber { get; set; }
    public string Username { get; set; }
  }
}
