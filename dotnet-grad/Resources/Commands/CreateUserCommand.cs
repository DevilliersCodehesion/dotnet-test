using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_grad.Dtos.Request;
using dotnet_grad.Models;
using MediatR;

namespace Resources.Commands
{
  public class CreateUserCommand : IRequest<UserModel>
  {
    public CreateUserCommand(UserRequestDto user)
    {
      Name = user.Name;
      Surname = user.Surname;
      IdNumber = user.IdNumber;
      Fullname = user.FullName;
      Email = user.Email;
      Username = user.Username;
    }

    public string Name { get; set; }
    public string Surname { get; set; }
    public string IdNumber { get; set; }
    public string Fullname { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
  }
}