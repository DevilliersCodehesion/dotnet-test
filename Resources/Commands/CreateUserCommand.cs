using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Resources.Commands
{
  public class CreateUserCommand : IRequest<UserModel>
  {
    public string Name { get; set; }
    public string Surname { get; set; }
    public string IdNumber { get; set; }
    public string Fullname { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
  }
}