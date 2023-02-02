using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resources.Commands
{
  public class UpdateUserCommand : IRequest<UserModel>
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string IdNumber { get; set; }
    public string Fullname { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
  }
}